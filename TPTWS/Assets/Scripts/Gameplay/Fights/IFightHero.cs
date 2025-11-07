using TPT.Gameplay.Grids;
using UnityEngine;

namespace TPT.Gameplay.Fights
{
    public interface IFightHero
    {
        bool IsPlayerHero { get; }
        bool IsAlive { get; }
        int MovementRange { get; }
        CellCoordinate Coordinates { get; }

        Awaitable OnTurnBegin();
        Awaitable OnTurnEnd();
        Awaitable MoveTo(CellCoordinate targetCoordinates);
    }
}