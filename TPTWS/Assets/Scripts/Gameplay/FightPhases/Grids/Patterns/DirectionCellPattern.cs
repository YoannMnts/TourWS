using System.Collections.Generic;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;

namespace TPT.Gameplay.FightPhases.Grids.Patterns
{
    public class DirectionCellPattern : ICellPattern
    {
        protected readonly int range;

        public DirectionCellPattern(int range)
        {
            this.range = range;
        }

        public void GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells)
        {
            for (int i = 1; i < range + 1; i++)
            {
                if (fightGrid.TryGetCell(coordinate.x, coordinate.y + i, out FightCell cell))
                    cells.Add(cell.Coordinates);
                
                if (fightGrid.TryGetCell(coordinate.x, coordinate.y - i, out cell))
                    cells.Add(cell.Coordinates);
                
                if (fightGrid.TryGetCell(coordinate.x + i, coordinate.y, out cell))
                    cells.Add(cell.Coordinates);
                
                if (fightGrid.TryGetCell(coordinate.x - i, coordinate.y, out cell))
                    cells.Add(cell.Coordinates);
            }
        }
    }
}