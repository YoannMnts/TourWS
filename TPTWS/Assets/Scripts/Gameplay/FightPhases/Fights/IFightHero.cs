using System;
using System.Collections.Generic;
using TPT.Gameplay.Fights.Attack;
using TPT.Gameplay.Grids;
using UnityEngine;

namespace TPT.Gameplay.Fights
{
    public interface IFightHero : IComparable<IFightHero>
    {
        Transform transform { get; }
        bool IsPlayerHero { get; }
        bool IsAlive { get; }
        int MovementSpeed { get; }
        int Speed { get; }
        CellCoordinate Coordinates { get; }

        Awaitable OnTurnBegin();
        Awaitable OnTurnEnd();
        Awaitable MoveTo(CellCoordinate targetCoordinates);
        
        IReadOnlyList<IFightSkill> Skills { get; }
    }
}