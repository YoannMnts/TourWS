using UnityEngine;

namespace TPT.Gameplay.FightPhases.Grids
{
    public interface IGridMember
    {
        FightGrid Grid { get; set; }
        Transform transform { get; }

        Awaitable MoveTo(CellCoordinate cellCoordinate);
    }
}