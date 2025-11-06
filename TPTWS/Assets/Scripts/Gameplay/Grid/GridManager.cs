using System;
using System.Linq;
using TPT.Gameplay.Player;
using UnityEngine;

namespace TPT.Gameplay
{
    public partial class GridManager : MonoBehaviour
    {
        private Grid grid;
        private Vector3 demiGridCellSize;

        [Header("Grid Settings")]
        [SerializeField]
        private GridParameter[] gridParameters;
        [SerializeField]
        private GameObject gridPrefab;
        
        private void Awake()
        {
            grid = GetComponent<Grid>();
            demiGridCellSize = grid.cellSize * 0.5f;
        }

        public void InitializeHeroPositionOnCell(Transform[] heroTransform)
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                for (int j = 0; j < gridParameters[i].heroSpawnPosition.Length; j++)
                {
                    var heroPosition = gridParameters[i].heroSpawnPosition[j] + 
                                       new Vector3Int(gridParameters[i].gridStartPos.x, 0, gridParameters[i].gridStartPos.y);
                    SnapHeroOnCell(heroTransform[j], heroPosition);
                }
            }
        }

        public void GenerateGrids(int gridIndex)
        {
            Debug.Log("ici");
            for (int j = 0; j < gridParameters[gridIndex].gridSize.x; j++)
            {
                for (int k = 0; k < gridParameters[gridIndex].gridSize.y; k++)
                {
                    Vector3 pos = new Vector3(
                        j + gridParameters[gridIndex].gridStartPos.x,
                        0, 
                        k + gridParameters[gridIndex].gridStartPos.y
                        )
                        + demiGridCellSize;
                    Instantiate(gridPrefab, pos, Quaternion.identity);
                }
            }
        }

        public void SnapHeroOnCell(Transform heroTransform, Vector3 coordinates)
        {
            heroTransform.position = coordinates;
        }
    }
}
