namespace DoubleVsDecimal
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Double: " + (0.3D == 0.2D + 0.1D));
            Console.WriteLine("Double equal enough " + AreEqual(0.3D, 0.2D + 0.1D, 0.000000001));
            Console.WriteLine(0d/0d);
            Console.WriteLine(0d/3d);
            Console.WriteLine(3d/0d);
            Console.WriteLine(-3d/0d);

            Console.WriteLine("Decimal: " + (0.3M == 0.2M + 0.1M));
            // Console.WriteLine(3M/0M); // DivideByZeroException
            Console.WriteLine(0M/3M);
        }

        // Equal enough
        public static bool AreEqual(double a, double b, double precision)
        {
            return Math.Abs(a - b) < precision;
        }
    }
}
