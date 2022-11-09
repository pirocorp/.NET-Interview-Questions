namespace PatternMatching
{
    public class Pet
    {
        public string Name { get; set; }

        public PetType PetType { get; set; }

        public float Weight { get; set; }

        public Pet(string name, PetType petType, float weight)
        {
            Name = name;
            PetType = petType;
            Weight = weight;
        }

        // Implementing Deconstruct method enables object deconstruction
        // Deconstruct methods can be add also to structs, records, and interfaces
        public void Deconstruct(out string name, out PetType type, out float weight)
        {
            name = this.Name;
            type = this.PetType;
            weight = this.Weight;
        }
    }
}
