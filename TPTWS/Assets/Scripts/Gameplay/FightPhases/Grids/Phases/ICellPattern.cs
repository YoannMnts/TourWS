using System.Collections.Generic;

namespace TPT.Gameplay.Grids.Phases
{
    public interface ICellPattern
    {
        void GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells, List<CellCoordinate> heroesCells);
    }
}