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
                    UpdateCoordinatesAndBoundsGizmos(heroPosition);
                    SnapHeroOnCellGizmos(i);
                    Gizmos.color = new Color(0.44f, 1f, 0.19f);
                    Gizmos.DrawCube(bounds.center, bounds.size);
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
                    Gizmos.DrawWireCube(pos + bounds.extents, bounds.size);
                }
            }
        }

        private void UpdateCoordinatesAndBoundsGizmos(Vector3 position)
        {
            coordinates = grid.WorldToCell(position);
            bounds = grid.GetBoundsLocal(coordinates);
            bounds.center = grid.GetCellCenterWorld(coordinates);
        }

        private void SnapHeroOnCellGizmos(int heroIndex)
        {
            player.spawnPoints[heroIndex].position = bounds.center;
        }
    }
}