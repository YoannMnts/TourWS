using TPT.Core.Phases;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.Fights.MovementPhase
{
    public class PlayerMovementPhase : MovementPhase
    {
        public PlayerMovementPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
            
        }

        protected override async Awaitable Execute()
        {
            FloodFillPattern pattern = new FloodFillPattern(Hero.MovementSpeed);
            
            SelectCellPhase selectCellPhase = new SelectCellPhase(Hero.Coordinates, Grid, pattern);
            
            await selectCellPhase.RunAsync();
            
            CellCoordinate targetCoordinates = selectCellPhase.SelectedCoordinate;
            
            await Hero.MoveTo(targetCoordinates);
        }
    }
}