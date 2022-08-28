using System;

namespace Services.GridService
{
    public readonly struct GridPosition : IEquatable<GridPosition>
    {
        public int X { get; }
        public int Z { get; }

        public GridPosition(int x, int z)
        {
            X = x;
            Z = z;
        }

        public override string ToString()
        {
            return $"X: {X}, Z: {Z}";
        }

        public static bool operator ==(GridPosition a, GridPosition b) => a.X.Equals(b.X) && a.Z.Equals(b.Z);

        public static bool operator !=(GridPosition a, GridPosition b) => !(a == b);

        public bool Equals(GridPosition gridPosition) => X == gridPosition.X && Z == gridPosition.Z;

        public override bool Equals(object obj) => obj is GridPosition gridPosition && Equals(gridPosition);

        public override int GetHashCode() => HashCode.Combine(X, Z);
    }
}