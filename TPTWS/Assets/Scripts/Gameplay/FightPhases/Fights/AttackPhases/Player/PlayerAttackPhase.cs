using System;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.Patterns;
using TPT.Gameplay.FightPhases.Grids.Phases;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.AttackPhases.Player
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
            Debug.Log(SelectedFightSkill);
            if (SelectedFightSkill.GetPattern(out ICellPattern attackPattern))
            { 
                SelectCellPhase selectCellPhase = new SelectCellPhase(Hero.Coordinates, Grid, attackPattern);

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
            this.Run();
        }
    }
}