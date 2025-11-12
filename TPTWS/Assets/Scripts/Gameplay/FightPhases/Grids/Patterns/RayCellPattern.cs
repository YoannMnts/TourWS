using System.Collections.Generic;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Grids.Phases
{
    public class RayCellPattern : ICellPattern
    {
        protected readonly int range;
        protected readonly Vector2Int direction;

        public RayCellPattern(int range, Vector2Int direction)
        {
            this.range = range;
            this.direction = direction;
        }


        public void GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells, List<CellCoordinate> heroesCells)
        {
            for (int i = 0; i < range; i++)
            {
                CellCoordinate to = new CellCoordinate()
                {
                    x = coordinate.x + direction.x * i,
                    y = coordinate.y + direction.y * i
                };
                
                cells.Add(to);
            }
        }
    }
}