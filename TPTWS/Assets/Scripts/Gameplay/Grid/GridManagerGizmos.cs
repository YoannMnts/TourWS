using TPT.Gameplay.Player;
using UnityEngine;

namespace TPT.Gameplay
{
    public partial class GridManager : MonoBehaviour
    {
        [Header("Other Settings")]
        [SerializeField]
        private PlayerController player;

        void OnDrawGizmos()
        {
            grid = GetComponent<Grid>();
            halfCellSize = grid.cellSize * 0.5f;
            GenerateGridsGizmos();
            InitializeHeroPositionGizmos(player.GetHeroPosition());
        }
        
        private void InitializeHeroPositionGizmos(Transform[] heroTransform)
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                for (int j = 0; j < gridParameters[i].heroSpawnPosition.Length; j++)
                {
                    Vector3 heroPosition = gridParameters[i].heroSpawnPosition[j] + 
                                       new Vector3Int(gridParameters[i].gridStartPos.x, 0, gridParameters[i].gridStartPos.y) +
                                       halfCellSize;
                    SnapHeroOnCell(heroTransform[j], heroPosition);
                    Gizmos.color = new Color(0.44f, 1f, 0.19f);
                    Gizmos.DrawCube(heroPosition, grid.cellSize);
                }
            }
        }

        private void GenerateGridsGizmos()
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                for (int j = 0; j < gridParameters[i].gridSize.x; j++)
                {
                    for (int k = 0; k < gridParameters[i].gridSize.y; k++)
                    {
                        Vector3 pos = new Vector3(
                                          j + gridParameters[i].gridStartPos.x, 
                                          0, 
                                          k + gridParameters[i].gridStartPos.y
                                          ) 
                                      + halfCellSize;
                        Gizmos.color = Color.white;
                        Gizmos.DrawWireCube(pos, grid.cellSize);
                    }
                }
            }
        }
    }
}