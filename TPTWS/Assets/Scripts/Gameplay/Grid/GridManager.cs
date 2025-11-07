using System;
using System.Linq;
using TPT.Gameplay.Player;
using UnityEngine;

namespace TPT.Gameplay
{
    public partial class GridManager : MonoBehaviour
    {
        private Grid grid;
        private Vector3 halfCellSize;
        private bool canSnap = true;

        [Header("Grid Settings")]
        [SerializeField]
        private GridParameter[] gridParameters;
        [SerializeField]
        private GameObject gridPrefab;


        private void Awake()
        {
            grid = GetComponent<Grid>();
            halfCellSize = grid.cellSize * 0.5f;
        }

        public void InitializeHeroPositionOnCell(Transform[] heroTransform)
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                for (int j = 0; j < gridParameters[i].heroSpawnPosition.Length; j++)
                {
                    var heroPosition = gridParameters[i].heroSpawnPosition[j] + GetGridStartPos(i);
                    SnapHeroOnCell(heroTransform[j], heroPosition);
                }
            }
        }
        
        public void GenerateGrids(int gridIndex)
        {
            for (int j = 0; j < gridParameters[gridIndex].gridSize.x; j++)
            {
                for (int k = 0; k < gridParameters[gridIndex].gridSize.y; k++)
                {
                    Vector3 pos = new Vector3(j, 0, k) + halfCellSize + GetGridStartPos(gridIndex);
                    Instantiate(gridPrefab, pos, Quaternion.identity);
                }
            }
        }

        public void EnableOrDisableSnapping(bool enable)
        {
            canSnap = enable;
        }
        
        private void SnapHeroOnCell(Transform heroTransform, Vector3 coordinates)
        {
            if (canSnap)
                heroTransform.position = coordinates;
        }
        
        private Vector3Int GetGridStartPos(int i)
        {
            return new Vector3Int(gridParameters[i].gridStartPos.x, 0, gridParameters[i].gridStartPos.y);
        }
    }
}
