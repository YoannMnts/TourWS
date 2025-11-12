using System;
using System.Collections.Generic;
using TPT.Gameplay.Fights.Attack;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.Fights
{
    public interface IFightHero : IComparable<IFightHero>, IGridMember
    {
        bool IsPlayerHero { get; }
        bool IsAlive { get; }
        int CurrentStrength { get; }
        int MovementSpeed { get; }
        int Speed { get; }
        CellCoordinate Coordinates { get; }

        Awaitable OnTurnBegin();
        Awaitable OnTurnEnd();
        
        IReadOnlyList<IFightSkill> Skills { get; }
        void AddOrRemoveHealth(int currentStrength);
    }
}