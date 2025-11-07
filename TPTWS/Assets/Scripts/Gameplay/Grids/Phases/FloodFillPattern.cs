using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Gameplay.Grids.Phases
{
    public class FloodFillPattern : ICellPattern
    {
        private readonly int range;

        public FloodFillPattern(int range)
        {
            this.range = range;
        }
        
        void ICellPattern.GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells)
        {
            using (ListPool<Vector2Int>.Get(out var list))
            {
                Flood(fightGrid, new Vector2Int(coordinate.x, coordinate.y), list, range);

                foreach (Vector2Int coord in list)
                {
                    if(fightGrid.TryGetCell(coord.x, coord.y, out FightCell cell))
                        cells.Add(cell.Coordinates);
                }
            }
        }

        public void Flood(FightGrid fightGrid, Vector2Int from, List<Vector2Int> cells, int budget)
        {
            Vector2Int up = new Vector2Int(from.x , from.y + 1);
            Vector2Int down = new Vector2Int(from.x, from.y - 1);
            Vector2Int right = new Vector2Int(from.x + 1, from.y);
            Vector2Int left = new Vector2Int(from.x - 1, from.y);

            CheckCell(fightGrid,  up, cells, budget);
            CheckCell(fightGrid, down, cells, budget);
            CheckCell(fightGrid, right, cells, budget);
            CheckCell(fightGrid, left, cells, budget);
        }

        private void CheckCell(FightGrid fightGrid,  Vector2Int cell, List<Vector2Int> cells, int budget)
        {
            if (!cells.Contains(cell) && fightGrid.HasCell(cell.x, cell.y))
            {
                cells.Add(cell);
                if(budget > 0)
                    Flood(fightGrid, cell, cells, budget - 1);
            }
        }
    }
}