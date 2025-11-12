using System.Collections.Generic;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;

namespace TPT.Gameplay.FightPhases.Grids.Phases
{
    public class AllCellsPattern : ICellPattern
    {
        public void GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells, List<CellCoordinate> heroesCells)
        {
            foreach (var cellCoordinate in fightGrid.CellCoordinates)
                cells.Add(cellCoordinate);
            
        }
    }
}