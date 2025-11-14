using System;
using TPT.Gameplay.Heroes;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Grids.SpawnPoint
{
    [Serializable]
    public struct PlayerSpawnPoint
    {
        [field: SerializeField]
        public PlayerHero PlayerHero { get; private set; }
    
        [field: SerializeField]
        public Transform SpawnPoint { get; private set; }
    }
}