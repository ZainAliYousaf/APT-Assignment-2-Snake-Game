namespace WinFormsApp1  
{
    /// <summary>
    /// Represents a single cell on the game grid.
    /// </summary>
    public readonly struct PointGrid
    {
        public int X { get; }
        public int Y { get; }

        public PointGrid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{X},{Y}";

        public static bool operator ==(PointGrid a, PointGrid b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(PointGrid a, PointGrid b) => !(a == b);

        public override bool Equals(object? obj) => obj is PointGrid p && p == this;
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}

