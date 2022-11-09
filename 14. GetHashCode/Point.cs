namespace GetHashCode
{
    using System;

    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }

        // When overriding the GetHashCode method is important to not forget
        // override Equals method too
        public override int GetHashCode()
        {
            // Most of the base types in C# already provide a good
            // implementation of the GetHashCode Method
            return HashCode.Combine(this.X, this.Y); // Combining two hash-codes into one
        }

        // Two points are equal when their coordinates are equal
        public override bool Equals(object? obj)
        {
            if (obj is Point point)
            {
                return this.X == point.X && this.Y == point.Y;
            }

            return false;
        }
    }
}
