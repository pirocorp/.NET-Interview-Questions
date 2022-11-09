namespace Deconstruction
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            var numbers = new[] { 1, 4, 2, 6, 11, 5, 83, 1, 2, 5, 7, 9 };

            // Deconstruction of ValueTuple
            // _ is a discard variable
            var (sum, _, average) = AnalyzeNumbers(numbers);

            // Console.WriteLine(count);
            Console.WriteLine(sum);
            Console.WriteLine(average);

            // Deconstruction of Tuple
            var tuple = Tuple.Create("abc", 10, true);
            var (text, number, boolean) = tuple;

            // Deconstruction of user defined class
            var pet = new Pet("Hannibal", PetType.Cat, 3.5F);
            var (name, type, weight) = pet;

            // Deconstruction with extension method
            var date = new DateTime();
            var (year, month, day) = date;
        }

        public static (int Sum, int Count, double Average) AnalyzeNumbers(
            IEnumerable<int> numbers)
        {
            var sum = 0;
            var count = 0;

            foreach (var number in numbers)
            {
                sum += number;
                count++;
            }

            var average = (double)sum / count;
            return (sum, count, average);
        }
    }
}