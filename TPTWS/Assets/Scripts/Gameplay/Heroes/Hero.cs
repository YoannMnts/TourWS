using System;
using System.Collections.Generic;
using DG.Tweening;
using TPT.Core.Core.Data.Heroes;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Fights.Attack;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TPT.Gameplay.Heroes
{
    public abstract class Hero : MonoBehaviour, IFightHero
    {
        
        protected class DebugSkill : IFightSkill
        {
            public async Awaitable Perform(IFightHero hero, FightGrid grid, CellCoordinate cellCoordinate)
            {
                Debug.Log("Debug attack");
                await Awaitable.WaitForSecondsAsync(1);
            }

            public bool GetPattern(out ICellPattern pattern)
            {
                pattern = null;
                return false;
            }
        }

        [field: SerializeField]
        public int MovementSpeed { get; private set; } = 2;
        
        [field: SerializeField]
        public int Speed { get; private set; } = 1;
        
        public int CurrentAttack { get; private set; }

        public int CurrentHealth { get; private set; } = 100;
        
        [field: SerializeField]
        public HeroData HeroData { get; private set; }
        
        [field: SerializeField]
        public List<IFightSkill> skills = new List<IFightSkill>()
        {
            new DebugSkill(),
        };
        
        public abstract bool IsPlayerHero { get; }
        public bool IsAlive => CurrentHealth > 0;
        public CellCoordinate Coordinates { get; private set; }
        IReadOnlyList<IFightSkill> IFightHero.Skills => skills.AsReadOnly();

        public async Awaitable OnTurnBegin()
        {
            Debug.Log($"Starting turn for {name}", gameObject);
            await Awaitable.WaitForSecondsAsync(.2f);
        }

        public async Awaitable OnTurnEnd()
        {
            Debug.Log($"Ending turn for {name}", gameObject);
            await Awaitable.WaitForSecondsAsync(.2f);
        }

        public async Awaitable MoveTo(CellCoordinate targetCoordinates)
        {
            Coordinates = targetCoordinates;
            
            await transform.DOMove(Coordinates.position, .5f)
                .SetEase(Ease.OutQuint)
                .AsyncWaitForCompletion();
        }

        int IComparable<IFightHero>.CompareTo(IFightHero other)
        {
            return Speed.CompareTo(other.Speed);
        }
    }
}