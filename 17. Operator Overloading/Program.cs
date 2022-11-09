namespace OperatorOverloading
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var pointA = new Point(10, 5);
            var pointB = new Point(-3, 4);

            var result = pointA + pointB;
            Console.WriteLine(result);

            var pointFromTuple = (Point)(5D, 6D);
            Console.WriteLine(pointFromTuple);
        }
    }

    public struct Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public Point Add(Point other)
            => new Point(this.X + other.X, this.Y + other.Y);

        public override string ToString()
            => $"X: {this.X}, Y: {this.Y}";

        // Operator + overloading
        public static Point operator +(Point a, Point b)
            => new (a.X + b.X, a.Y + b.Y);

        // Implicit operator(cast) overloading
        // public static implicit operator Point((double X, double Y) point)
        //    => new (point.X, point.Y);

        // Explicit operator(cast) overloading
        public static explicit operator Point((double X, double Y) point)
            => new (point.X, point.Y);
    }
}
