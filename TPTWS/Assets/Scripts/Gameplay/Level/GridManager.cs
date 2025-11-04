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

        private void Awake()
        {
            grid = GetComponent<Grid>();
        }

        void OnDrawGizmos()
        {
            grid = GetComponent<Grid>();
            for (int k = 0; k < player.spawnPoints.Length; k++)
            {
                Vector3 position = player.spawnPoints[k].position;
                var coordinates = GetCellPosition(position);
                var bounds = GetBounds(coordinates);
                player.spawnPoints[k].position = bounds.center;
                
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
                
                Gizmos.color = new Color(0.44f, 1f, 0.19f);
                Gizmos.DrawCube(bounds.center, bounds.size);
                
            }
        }

        private Bounds GetBounds(Vector3Int coordinates)
        {
            var bounds = grid.GetBoundsLocal(coordinates);
            bounds.center = grid.GetCellCenterWorld(coordinates);
            return bounds;
        }

        private Vector3Int GetCellPosition(Vector3 position)
        {
            var coordinates = grid.WorldToCell(position);
            return coordinates;
        }
    }
}
