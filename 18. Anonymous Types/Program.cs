namespace AnonymousTypes
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var person = new { Name = "Martin", City = "Savannah", Age = 30 };

            // The properties of anonymous type are readonly
            // person.Name = "Jack";

            Console.WriteLine($"The person name is {person.Name}, he/she lives in {person.City}" 
                              + $" and is {person.Age} years old");

            Demo();

            var x = new { Name = "A" };
            var y = new { Name = "A" };

            Console.WriteLine(x == y); // False
            Console.WriteLine(x.Equals(y)); // True
        }

        public static void Demo()
        {
            var pets = new[]
            {
                new Pet("Hannibal", PetType.Fish, 1.1),
                new Pet("Anthony", PetType.Cat, 2),
                new Pet("Ed", PetType.Cat, 0.7),
                new Pet("Taiga", PetType.Dog, 35),
                new Pet("Rex", PetType.Dog, 40),
                new Pet("Lucky", PetType.Dog, 5),
                new Pet("Storm", PetType.Cat, 0.9),
                new Pet("Nyan", PetType.Cat, 2.2),
            };

            var result = pets
                .GroupBy(p => p.PetType)
                .Select(g => new
                {
                    PetType = g.Key,
                    AverageWeight = g.Average(p => p.Weight)
                })
                .OrderBy(data => data.AverageWeight)
                .Select(data => $"Average weight for {data.PetType} is {data.AverageWeight:F2}")
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public record Pet(string Name, PetType PetType, double Weight);
}
