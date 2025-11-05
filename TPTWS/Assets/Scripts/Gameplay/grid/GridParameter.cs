using UnityEngine;

namespace TPT.Gameplay
{
    [System.Serializable]
    public class GridParameter
    {
        public Vector2Int gridSize;
        public Vector2Int gridStartPos;
        public Vector3[] heroSpawnPosition;
    }
}