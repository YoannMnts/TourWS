using System;
using System.Linq;
using TPT.Gameplay.Player;
using UnityEngine;

namespace TPT.Gameplay
{
    public partial class GridManager : MonoBehaviour
    {
        private Grid grid;

        [Header("Grid Settings")]
        [SerializeField]
        private GridParameter[] gridParameters;
        [SerializeField]
        private GameObject gridPrefab;
        
        [Header("Other Settings")]
        [SerializeField]
        private PlayerController player;

        private void Awake()
        {
            grid = GetComponent<Grid>();
        }

        private void OnEnable()
        {
            InitializeHeroPosition();
            GenerateGrids();
        }

        private void InitializeHeroPosition()
        {
            for (int i = 0; i < player.spawnPoints.Length; i++)
            {
                for (int j = 0; j < gridParameters[i].heroSpawnPosition.Length; j++)
                {
                    var heroPosition = gridParameters[i].heroSpawnPosition[j];
                    SnapHeroOnCell(j, heroPosition);
                }
            }
        }

        private void GenerateGrids()
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                MakeGridCell(i);
            }
        }

        private void MakeGridCell(int gridIndex)
        {
            for (int i = 0; i < gridParameters[gridIndex].gridSize.x; i++)
            {
                for (int j = 0; j < gridParameters[gridIndex].gridSize.y; j++)
                {
                    Vector3 pos = new Vector3(
                        i + gridParameters[gridIndex].gridStartPos.x,
                        0, 
                        j + gridParameters[gridIndex].gridStartPos.y
                        );
                    Instantiate(gridPrefab, pos, Quaternion.identity);
                }
            }
        }

        private void SnapHeroOnCell(int heroIndex, Vector3Int coordinates)
        {
            player.spawnPoints[heroIndex].position = coordinates;
        }
    }
}
