using UnityEngine;

namespace TPT.Gameplay
{
    public partial class GridManager : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            grid = GetComponent<Grid>();
            InitializeHeroPositionGizmos();
            GenerateGridsGizmos();
        }
        
        private void InitializeHeroPositionGizmos()
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                for (int j = 0; j < gridParameters[i].heroSpawnPosition.Length; j++)
                {
                    var heroPosition = gridParameters[i].heroSpawnPosition[j];
                    SnapHeroOnCell(j, heroPosition);
                    Gizmos.color = new Color(0.44f, 1f, 0.19f);
                    Gizmos.DrawCube(heroPosition, grid.cellSize);
                }
            }
        }

        private void GenerateGridsGizmos()
        {
            for (int i = 0; i < gridParameters.Length; i++)
            {
                MakeGridCellGizmos(i);
            }
        }

        private void MakeGridCellGizmos(int gridIndex)
        {
            for (int i = 0; i < gridParameters[gridIndex].gridSize.x; i++)
            {
                for (int j = 0; j < gridParameters[gridIndex].gridSize.y; j++)
                {
                    Vector3 pos = new Vector3(i + gridParameters[gridIndex].gridStartPos.x, 0, j + gridParameters[gridIndex].gridStartPos.y);
                    Gizmos.color = Color.white;
                    Gizmos.DrawWireCube(pos, grid.cellSize);
                }
            }
        }
    }
}