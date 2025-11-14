using System.Collections.Generic;

namespace TPT.Gameplay.FightPhases.Grids.Patterns
{
    public interface ICellPattern
    {
        void GetCells(FightGrid fightGrid, CellCoordinate coordinate, List<CellCoordinate> cells);
    }
}