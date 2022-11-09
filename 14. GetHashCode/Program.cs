namespace GetHashCode
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var anyObject1 = "abc";
            var anyObject2 = 123;

            // The GetHashCode method is a hash function implementation for an object
            // A hash function is a one-way algorithm that maps an input of any size
            // to a unique output of a fixed length of bits.
            Console.WriteLine($"'{anyObject1}' hash code is {anyObject1.GetHashCode()}");
            Console.WriteLine($"'{anyObject2}' hash code is {anyObject2.GetHashCode()}");

            // Two object considered equal should have the same hash code.
            // Default implementation for reference types is based on reference (memory address)
            // For value types is calculated based on the values stored.
            var point1 = new Point(10, 20);
            var point2 = new Point(10, 20);
            var point3 = new Point(20, 20);

            Console.WriteLine($"{point1.GetType().Name} hash code is {point1.GetHashCode()}");
            Console.WriteLine($"{point2.GetType().Name} hash code is {point2.GetHashCode()}");
            Console.WriteLine($"{point3.GetType().Name} hash code is {point3.GetHashCode()}");
        }
    }
}