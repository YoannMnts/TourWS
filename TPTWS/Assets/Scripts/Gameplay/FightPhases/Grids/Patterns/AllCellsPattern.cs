using System.Collections.Generic;

namespace TPT.Gameplay.FightPhases.Grids.Patterns
{
    public class AllCellsPattern : ICellPattern
    {
        public void GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells)
        {
            foreach (var cellCoordinate in fightGrid.CellCoordinates)
                cells.Add(cellCoordinate);
        }
    }
}