namespace PatternMatching
{
    using System;

    public static class Program
    {
        public static void Main()
        {
        }

        public static void StringCheck(object obj)
        {
            if (obj is string asString)
            {
                Console.WriteLine("String is: " + asString);
            }

            Console.WriteLine("Not a string!");
        }

        public static string Properties(object obj)
        {
            if (obj is Pet { Weight: > 1000, PetType: PetType.Fish })
            {
                return "It must be a whale shark!";
            }

            if (obj is Pet)
            {
                return "It's some pet";
            }

            return "Definitely not a pet";
        }

        public static object ComparingDiscreteValues(string number, string type)
        {
            // switch expression
            return type switch
            {
                "int" => int.Parse(number),
                "decimal" => decimal.Parse(number),
                "float" => float.Parse(number),
                // discard pattern works similarly like default in switch statement
                _ => throw new ArgumentException($"type '{type} is not supported'")
            };
        }

        public static string Relational(int age)
        {
            return age switch
            {
                18 => "just an adult, at least in some countries",
                < 11 => "child",
                (>= 20) and (<60) => "middle-aged", // logical pattern
                < 20 => "teen",
                >= 60 => "senior"
            };
        }

        public static string Deconstruction(Pet pet)
        {
            return pet switch
            {
                (_, type: PetType.Dog, weight: 10) => "Small dog of any name",
                (name: "Hannibal", type: PetType.Fish, _) => "Fish called Hannibal",
                Pet { Weight: > 100 } => "Heavy pet!", // Properties matching
                _ => "Unknown pet!"
            };
        }
    }
}
