using System;
using TPT.Gameplay.Heroes;
using UnityEngine;

namespace TPT.Gameplay.Grids
{
    [Serializable]
    public struct EnemySpawnPoints
    {
        [field: SerializeField]
        public EnemyHero Enemy { get; private set; }
        
        [field: SerializeField]
        public Transform SpawnPoint { get; private set; }
    }
}