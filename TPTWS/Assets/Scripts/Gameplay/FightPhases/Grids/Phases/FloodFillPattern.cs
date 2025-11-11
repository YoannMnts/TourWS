using System.Collections.Generic;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Gameplay.FightPhases.Grids.Phases
{
    public class FloodFillPattern : ICellPattern
    {
        private readonly int range;

        public FloodFillPattern(int range)
        {
            this.range = range;
        }
        
        void ICellPattern.GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells,List<CellCoordinate> heroesCells)
        {
            using (ListPool<Vector2Int>.Get(out var list))
            {
                Flood(fightGrid, new Vector2Int(coordinate.x, coordinate.y), list, range, heroesCells);
                
                foreach (Vector2Int coord in list)
                {
                    if (fightGrid.TryGetCell(coord.x, coord.y, out FightCell cell))
                    {
                        Debug.Log($"list of cells by flood : {coord}");
                        cells.Add(cell.Coordinates);
                    }
                }
            }
        }

        public void Flood(FightGrid fightGrid, Vector2Int from, List<Vector2Int> cells, int budget, List<CellCoordinate> heroesCells)
        {
            Vector2Int up = new Vector2Int(from.x, from.y + 1);
            Vector2Int down = new Vector2Int(from.x, from.y - 1);
            Vector2Int right = new Vector2Int(from.x + 1, from.y);
            Vector2Int left = new Vector2Int(from.x - 1, from.y);
            
            CheckCell(fightGrid, from, cells, budget, heroesCells);
            CheckCell(fightGrid, right, cells, budget, heroesCells);
            CheckCell(fightGrid, left, cells, budget, heroesCells);
            CheckCell(fightGrid,  up, cells, budget, heroesCells);
            CheckCell(fightGrid, down, cells, budget, heroesCells);
            
            Debug.Log($"From {from} to {up} => {down} => {right} => {left}");
        }

        private void CheckCell(FightGrid fightGrid,  Vector2Int cell, List<Vector2Int> cells, int budget, List<CellCoordinate> heroesCells)
        {
            var currentCell = new CellCoordinate()
            {
                position = new Vector3(cell.x, 0, cell.y),
                x = cell.x,
                y = cell.y
            };
            if (!heroesCells.Contains(currentCell))
            {
                budget--;
                if (!cells.Contains(cell))
                {
                    cells.Add(cell);
                    if(budget > 0)
                        Flood(fightGrid, cell, cells, budget - 1, heroesCells);
                }
            }
        }
    }
}