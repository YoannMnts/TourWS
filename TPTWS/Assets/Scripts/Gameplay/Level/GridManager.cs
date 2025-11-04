using System;
using TPT.Gameplay.Player;
using UnityEditor;
using UnityEngine;

namespace TPT.Gameplay
{
    public class GridManager : MonoBehaviour
    {
        private Grid grid;
        [Header("Grid Settings")]
        [SerializeField]
        private Vector2 gridSize;
        [SerializeField] 
        private Vector2Int gridStartPos;
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
            GenerateGrid();
        }

        void OnDrawGizmos()
        {
            grid = GetComponent<Grid>();
            InitializeHeroPosition();
            GenerateGrid();
        }

        private void InitializeHeroPosition()
        {
            for (int i = 0; i < player.spawnPoints.Length; i++)
            {
                var heroPosition = player.spawnPoints[i].position;
                UpdateCoordinatesAndBounds(heroPosition);
                SnapHeroOnCell(i);
                
                Gizmos.color = new Color(0.44f, 1f, 0.19f);
                Gizmos.DrawCube(bounds.center, bounds.size);
                
            }
        }

        private void GenerateGrid()
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    Vector3 pos = new Vector3(i + gridStartPos.x, 0, j + gridStartPos.y);
                    //Instantiate(gridPrefab, pos + bounds.extents, Quaternion.identity);
                        
                    Gizmos.color = Color.white;
                    Gizmos.DrawWireCube(pos + bounds.extents, bounds.size);
                        
                }
            }
        }

        private void UpdateCoordinatesAndBounds(Vector3 position)
        {
            coordinates = grid.WorldToCell(position);;
            bounds = grid.GetBoundsLocal(coordinates);
            bounds.center = grid.GetCellCenterWorld(coordinates);
        }

        private void SnapHeroOnCell(int index)
        {
            player.spawnPoints[index].position = bounds.center;
        }
    }
}
