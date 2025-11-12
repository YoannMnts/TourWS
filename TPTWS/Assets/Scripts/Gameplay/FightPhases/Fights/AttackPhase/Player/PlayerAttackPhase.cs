using System;
using System.Collections.Generic;
using TPT.Core.Phases;
using TPT.Gameplay.Fights.Attack;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Fights.AttackPhase.Player
{
    public class PlayerAttackPhase : AttackPhase
    {
        public event Action<IFightSkill> OnAttackSelected;
        
        public IFightSkill SelectedFightSkill { get; private set; }
        
        public PlayerAttackPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
            
        }

        protected override async Awaitable Execute()
        {
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
                await SelectedFightSkill.Perform(Hero, Grid, Hero.Coordinates);
            }
        }

        public void SelectSkill(IFightSkill fightSkill)
        {
            SelectedFightSkill = fightSkill;
        }
    }
}