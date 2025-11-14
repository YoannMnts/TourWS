using UnityEngine;

namespace TPT.Gameplay.Grids
{
    public interface IGridMember
    {
        FightGrid Grid { get; set; }
        Transform transform { get; }

        Awaitable MoveTo(CellCoordinate cellCoordinate);
    }
}