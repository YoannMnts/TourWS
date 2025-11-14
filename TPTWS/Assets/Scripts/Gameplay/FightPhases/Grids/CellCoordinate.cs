using System;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Grids
{
    public struct CellCoordinate : IEquatable<CellCoordinate>
    {
        public int x;
        public int y;
        
        public Vector3 position;
        
        public CellCoordinate(int x, int y, Vector3 position)
        {
            this.x = x;
            this.y = y;
            this.position = position;
        }
        
        public static implicit operator Vector2Int(CellCoordinate coordinate)
            => new Vector2Int(coordinate.x, coordinate.y);

        public bool Equals(CellCoordinate other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            return obj is CellCoordinate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}