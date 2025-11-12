using System.Collections.Generic;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Heroes;
using UnityEngine;
using UnityEngine.Pool;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TPT.Gameplay.Grids
{
    [RequireComponent(typeof(BoxCollider))]
    [ExecuteInEditMode]
    public class FightGrid : MonoBehaviour
    {
        [SerializeField] 
        private BoxCollider zone;
        [SerializeField] 
        private FightCell cellPrefab;
        [SerializeField] 
        private Transform cellRoot;

        [field: SerializeField] 
        public EnemySpawnPoints[] Enemies { get; private set; }
        
        [field: SerializeField] 
        public PlayerSpawnPoint[] PlayerHero { get; private set; }
        
        private Dictionary<CellCoordinate, FightCell> cells;
        
        [SerializeField, HideInInspector]
        private FightGridManager manager;

        public IEnumerable<CellCoordinate> CellCoordinates => cells.Keys;
        
        public Dictionary<IGridMember, CellCoordinate> Members { get; private set; }


        private void Reset()
        {
            zone = GetComponent<BoxCollider>();
            manager = FindFirstObjectByType<FightGridManager>();
        }

        private void Awake()
        {
            Members = new ();
            //Degeu mais tant pis
            if(manager == null)
                manager = FindFirstObjectByType<FightGridManager>();
            
            cells = new Dictionary<CellCoordinate, FightCell>();
        }

        private void OnEnable()
        {
            manager.AddGrid(this);
        }

        private void OnDisable()
        {
            manager.RemoveGrid(this);
        }

        public Awaitable AddMember(IGridMember member)
        {
            if(member.Grid != this)
                member.Grid?.RemoveMember(member);
            
            member.Grid = this;
            FightCell cell = GetNearestCellCoord(member.transform.position);
            Members.Add(member, cell.Coordinates);
            
            return member.MoveTo(cell.Coordinates);
        }

        public void RemoveMember(IGridMember member)
        {
            Members.Remove(member);
        }

        public Awaitable MoveMember(IGridMember gridMember, CellCoordinate cellCoordinate)
        {
            if (TryGetCell(cellCoordinate, out FightCell cell))
            {
                Members[gridMember] = cell.Coordinates;
                return gridMember.MoveTo(cell.Coordinates);
            }

            return Awaitable.EndOfFrameAsync();
        }
        public Awaitable MoveMember(IGridMember gridMember, int x, int y)
        {
            if (TryGetCell(x, y, out FightCell cell))
            {
                Members[gridMember] = cell.Coordinates;
                return gridMember.MoveTo(cell.Coordinates);
            }

            return Awaitable.EndOfFrameAsync();
        }

        public bool TryGetMember(int x, int y, out IGridMember member)
        {
            if(TryGetCell(x, y, out FightCell cell))
                return TryGetMember(cell.Coordinates, out member);
            
            member = null;
            return false;
        }
        public bool TryGetMember(CellCoordinate cellCoordinate, out IGridMember member)
        {
            foreach (var (gridMember, coord) in Members)
            {
                if (cellCoordinate.Equals(coord))
                {
                    member = gridMember;
                    return true;
                }
            }
            
            member = null;
            return false;
        }
        public bool TryGetMemberCoord(IGridMember member, out CellCoordinate cell) => Members.TryGetValue(member, out cell);
        public bool TryGetMemberCell(IGridMember member, out FightCell cell)
        {
            if(Members.TryGetValue(member, out CellCoordinate coordinate) && cells.TryGetValue(coordinate, out cell))
                return true;
            
            cell = null;
            return false;
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
                    
                    Handles.Label(cellCoordinate.position, $"{cellCoordinate.x} : {cellCoordinate.y}");
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
        public void GenerateCells()
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

        public void DestroyCells()
        {
            foreach ((_, FightCell fightCell) in cells)
            {
                fightCell.Unbind();
                Destroy(fightCell.gameObject);
            }
            
            cells.Clear();
        }

        
        public FightCell GetCellSpawn(IFightHero fightHero)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                if ((IFightHero)Enemies[i].Enemy == fightHero)
                    return GetNearestCellCoord(Enemies[i].SpawnPoint.position);
            }
            for (int j = 0; j < PlayerHero.Length; j++)
            {
                if ((IFightHero)PlayerHero[j].PlayerHero == fightHero)
                    return GetNearestCellCoord(PlayerHero[j].SpawnPoint.position);
            }
            return null;
        }
    }
}