using System;
using System.Collections.Generic;
using TPT.Core.Phases;
using TPT.Gameplay.Fights;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Gameplay.Grids
{
    [RequireComponent(typeof(BoxCollider))]
    [ExecuteInEditMode]
    public class FightGrid : MonoBehaviour, IPhaseListener<FightPhase>
    {
        [SerializeField] 
        private BoxCollider zone;
        [SerializeField] 
        private FightCell cellPrefab;
        [SerializeField] 
        private Transform cellRoot;
        
        private Dictionary<CellCoordinate, FightCell> cells;
        

        [SerializeField, HideInInspector]
        private FightGridManager manager;

        private void Reset()
        {
            zone = GetComponent<BoxCollider>();
            manager = FindFirstObjectByType<FightGridManager>();
        }

        private void Awake()
        {
            //Degeu mais tant pis
            if(manager == null)
                manager = FindFirstObjectByType<FightGridManager>();
            
            cells = new Dictionary<CellCoordinate, FightCell>();
        }

        private void OnEnable()
        {
            manager.AddGrid(this);
            this.AddListener();
        }

        private void OnDisable()
        {
            manager.RemoveGrid(this);
            this.RemoveListener();
        }
        
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            using (ListPool<CellCoordinate>.Get(out var list))
            {
                GetCells(list);
                foreach (var cellCoordinate in list)
                {
                    Vector3 vector3 = new Vector3(manager.CellSize, .2f, manager.CellSize);
                    Gizmos.DrawWireCube(cellCoordinate.position, vector3);
                }
            }
        }
#endif
        private void GetCells(List<CellCoordinate> coordinates)
        {
            Bounds bounds = zone.bounds;

            float cellSize = manager.CellSize;
            float halfSize = cellSize * 0.5f;
            int width = Mathf.CeilToInt(bounds.size.x / cellSize);
            int depth = Mathf.CeilToInt(bounds.size.z / cellSize);

            for (int y = 0; y < depth; y++)
            {
                float worldZ = bounds.min.z + y * cellSize + halfSize;
                
                for (int x = 0; x < width; x++)
                {
                    float worldX = bounds.min.x + x * cellSize + halfSize;
                    
                    Vector3 start = new Vector3(worldX, bounds.max.y, worldZ);
                    Vector3 end = new Vector3(worldX, bounds.min.y, worldZ);

                    if (!Physics.Linecast(start, end, out RaycastHit hit, manager.GroundLayer))
                        continue;
                    
                    Vector3 pos = hit.point;
                    if(Physics.CheckBox(pos, Vector3.one * halfSize, Quaternion.identity, manager.ObstaclesLayer))
                        continue;
                    
                    coordinates.Add(new CellCoordinate()
                    {
                        x = x,
                        y = y,
                        position = pos,
                    });
                }
            }
        }

        private void DestroyCells()
        {
            foreach ((_, FightCell fightCell) in cells)
            {
                fightCell.Unbind();
                Destroy(fightCell.gameObject);
            }
            
            cells.Clear();
        }

        public bool HasCell(int x, int y) => TryGetCell(x, y, out _);
        public bool TryGetCell(int x, int y, out FightCell cell)
        {
            foreach ((CellCoordinate cellCoordinate, FightCell fightCell) in cells)
            {
                if (cellCoordinate.x == x && cellCoordinate.y == y)
                {
                    cell = fightCell;
                    return true;
                }
            }
            
            cell = null;
            return false;
        }
        
        public bool TryGetCell(CellCoordinate coordinate, out FightCell cell) =>
            cells.TryGetValue(coordinate, out cell);

        public FightCell GetNearestCellCoord(Vector3 position)
        {
            float distance = float.MaxValue;
            FightCell nearestCell = null;
            
            foreach ((CellCoordinate cellCoordinate, FightCell fightCell) in cells)
            {
                float cellDistance = (cellCoordinate.position - position).sqrMagnitude;
                if (cellDistance < distance)
                {
                    distance = cellDistance;
                    nearestCell = fightCell;
                }
            }
            
            return nearestCell;
        }
        void IPhaseListener<FightPhase>.OnPhaseBegin(FightPhase phase)
        {
            if (phase.fightGrid == this)
            {
                DestroyCells();
                
                using (ListPool<CellCoordinate>.Get(out var list))
                {
                    GetCells(list);
                    foreach (var cellCoordinate in list)
                    {
                        FightCell instance = Instantiate(cellPrefab, cellRoot);
                        instance.transform.position = cellCoordinate.position;
                        cells.Add(cellCoordinate, instance);

                        instance.Bind(cellCoordinate, this);
                    }
                }
            }
        }
        void IPhaseListener<FightPhase>.OnPhaseEnd(FightPhase phase)
        {
            if (phase.fightGrid == this)
            {
                DestroyCells();
            }
        }

    }
}