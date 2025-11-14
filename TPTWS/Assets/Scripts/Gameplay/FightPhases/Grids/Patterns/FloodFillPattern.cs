using System.Collections.Generic;
using System.Linq;
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
        
        void ICellPattern.GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells)
        {
            Debug.Log($"Movement range : {range}");
            using (HashSetPool<Vector2Int>.Get(out var list))
            {
                list.Clear();
                Flood(fightGrid, new Vector2Int(coordinate.x, coordinate.y), list, range);
                
                foreach (Vector2Int coord in list)
                {
                    if(coord.x == coordinate.x && coord.y == coordinate.y)
                        continue;
                    
                    if (fightGrid.TryGetCell(coord.x, coord.y, out FightCell cell))
                    {
                        //Debug.Log($"list of cells by flood : {coord}");
                        cells.Add(cell.Coordinates);
                    }
                }
            }
        }

        private static void Flood(FightGrid fightGrid, Vector2Int from, HashSet<Vector2Int> cells, int budget)
        {
            Vector2Int up = new Vector2Int(from.x, from.y + 1);
            Vector2Int down = new Vector2Int(from.x, from.y - 1);
            Vector2Int right = new Vector2Int(from.x + 1, from.y);
            Vector2Int left = new Vector2Int(from.x - 1, from.y);
            
            //Debug.Log($"From {from} to {up} => {down} => {right} => {left} budget : {budget}");
            CheckCell(fightGrid, right, cells, budget);
            CheckCell(fightGrid, left, cells, budget);
            CheckCell(fightGrid,  up, cells, budget);
            CheckCell(fightGrid, down, cells, budget);
            
        }

        private static void CheckCell(FightGrid fightGrid,  Vector2Int cell, HashSet<Vector2Int> cells, int budget)
        {
            //Debug.Log($"Cell {cell} being checked for {budget}");
            bool isHeroHere = fightGrid.TryGetMember(cell.x, cell.y, out var gridMember);
            
            if(isHeroHere || budget <= 0)
                return;
            
            cells.Add(cell);
            
            budget--;
            Flood(fightGrid, cell, cells, budget);
        }
    }
}