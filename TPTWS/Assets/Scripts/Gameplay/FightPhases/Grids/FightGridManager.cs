using System;
using System.Collections.Generic;
using UnityEngine;

namespace TPT.Gameplay.Grids
{
    public class FightGridManager : MonoBehaviour
    {
        [field: SerializeField]
        public float CellSize { get; private set; }
        [field: SerializeField]
        public LayerMask GroundLayer { get; private set; }
        [field: SerializeField]
        public LayerMask ObstaclesLayer { get; private set; }
        
        private List<FightGrid> grids = new List<FightGrid>();
        
        public void AddGrid(FightGrid fightGrid)
        {
            grids.Add(fightGrid);
        }

        public void RemoveGrid(FightGrid fightGrid)
        {
            grids.Remove(fightGrid);
        }
    }
}