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

        private Bounds bounds;
        private Vector3Int coordinates;

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
                var heroPosition = player.spawnPoints[i].position;
                UpdateCoordinatesAndBounds(heroPosition);
                SnapHeroOnCell(i);
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
                    Vector3 pos = new Vector3(i + gridParameters[gridIndex].gridStartPos.x, 0, j + gridParameters[gridIndex].gridStartPos.y);
                    Instantiate(gridPrefab, pos + bounds.extents, Quaternion.identity);
                }
            }
        }

        private void UpdateCoordinatesAndBounds(Vector3 position)
        {
            coordinates = grid.WorldToCell(position);;
            bounds = grid.GetBoundsLocal(coordinates);
            bounds.center = grid.GetCellCenterWorld(coordinates);
        }

        private void SnapHeroOnCell(int heroIndex)
        {
            player.spawnPoints[heroIndex].position = bounds.center;
        }
    }
}
