using System.Collections.Generic;
using TPT.Gameplay.Skills;
using UnityEngine;
using System;
using System.Linq;
using TPT.Gameplay.Fights.Attack;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

namespace TPT.Gameplay.FightPhases.Fights.AttackPhases.Enemy
{
    public class EnemyAttackPhase : AttackPhase
    {
        public event Action<IFightSkill> OnAttackSelected;
        
        public IFightSkill SelectedFightSkill { get; private set; }
        public EnemyAttackPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
        }

        protected override async Awaitable Execute()
        {
            var pattern = new FloodFillPattern(Hero.MovementSpeed);
            var enemyCells = heroTurnPhase.heroesCells;

            var cellsEnemyPhases = new SelectCellPhase(Hero.Coordinates, Grid, pattern, enemyCells);
            await ((IPhase)cellsEnemyPhases).Begin(); 

            if (enemyCells == null || enemyCells.Count == 0)
            return;
            SelectedFightSkill = Hero.Skills[0];
            while (SelectedFightSkill == null)
                await Awaitable.NextFrameAsync();
            
            OnAttackSelected?.Invoke(SelectedFightSkill);
            
            if (SelectedFightSkill.GetPattern(out ICellPattern attackPattern))
            { 
                List<CellCoordinate> heroesCells = heroTurnPhase.heroesCells;
                SelectCellPhase selectCellPhase = new SelectCellPhase(Hero.Coordinates, Grid, attackPattern, heroesCells);

                await selectCellPhase.RunAsync();
                CellCoordinate target = selectCellPhase.SelectedCoordinate;
                
                await SelectedFightSkill.Perform(Hero, Grid, target);
            }
            else
            {
                Debug.Log($"{heroTurnPhase.hero} uses random skill instead");

                IReadOnlyList<IFightSkill> attacks = Hero.Skills;
                if (attacks.Count == 0)
                    return;

                int rnd = Random.Range(0, attacks.Count);
                IFightSkill atk = attacks[rnd];

                await atk.Perform(Hero, Grid, Hero.Coordinates);
            }
        }
        private int Distance(CellCoordinate a, CellCoordinate b)
        {
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.x - b.x);
        }
        
        private CellCoordinate GetClosestCell(IReadOnlyList<CellCoordinate> cells, CellCoordinate hero)
        {
            return cells.OrderBy(c => Distance(c, hero)).First();
        }
    }
}