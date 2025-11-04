using System;
using TPT.Gameplay.Player;
using UnityEditor;
using UnityEngine;

namespace TPT.Gameplay
{
    public class GridManager : MonoBehaviour
    {
        private Grid grid;
        [SerializeField]
        private Vector2 gridSize;
        [SerializeField]
        private PlayerController player;

        private void Awake()
        {
            
        }

        void OnDrawGizmos()
        {
            grid = GetComponent<Grid>();
            Debug.Log(grid.cellSize);
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    Vector3 pos = new Vector3(i, 0, j);
                    Gizmos.color = Color.white;
                    for (int k = 0; k < player.spawnPoints.Length; k++)
                    {
                        Gizmos.color = Color.cyan;
                        Vector3 position = player.spawnPoints[k].position;
                        var coordinates = grid.WorldToCell(position);
                        var bounds = grid.GetBoundsLocal(coordinates);
                        var center = grid.GetCellCenterWorld(coordinates);
                        
                        Gizmos.DrawWireCube(center, bounds.size);

                        /*
                        Vector3Int targetGridPosition = Vector3Int.RoundToInt(position);
                        Debug.Log($"target grid pos ==> {targetGridPosition}");
                        Gizmos.DrawWireCube(grid.GetCellCenterLocal(targetGridPosition), grid.cellSize);
                        */
                    }
                    
                }
            }
        }
    }
}
