using System.Linq;
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
            
            Debug.Log($"hero coordinates : {Hero.Coordinates.x}, {Hero.Coordinates.y}");
            SelectCellPhase selectCellPhase = new SelectCellPhase(Hero.Coordinates, Grid, pattern);
            
            await selectCellPhase.RunAsync();

            CellCoordinate targetCoordinates = selectCellPhase.SelectedCoordinate;
            
            if (selectCellPhase.Cells.Contains(targetCoordinates))
            {
                await Hero.MoveTo(targetCoordinates);
            }
        }
    }
}