namespace Reflection
{
    using System;
    using System.Linq;

    public record Pet(string Name, PetType PetType, float Weight);

    public record House(string Address, double Area, int Floors);

    public static class Program
    {
        public static void Main(string[] args)
        {
            var pet = new Pet("Hannibal", PetType.Cat, 3.5F);
            var house = new House("Valkendal 8", 250, 4);

            var converter = new ObjectToTextConverter();

            Console.WriteLine(converter.Convert(pet));
            Console.WriteLine(converter.Convert(house));
        }

        public class ObjectToTextConverter
        {
            public string Convert(object obj)
            {
                var type = obj.GetType();

                var properties = type
                    .GetProperties()
                    .Where(p => p.Name != "EqualityContract")
                    .Select(p => $"{p.Name} is {p.GetValue(obj)}");

                return string.Join(", ", properties);
            }
        }
    }
}