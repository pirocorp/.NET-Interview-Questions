namespace ExpressionBodyMembers
{
    using System;

    public static class Program
    {
        public static void Main()
        {
        }
    }

    public class Person
    {
        private string lastName;

        public Person(string name) // Expression Body Constructor
            => this.Name = name;

        public Person(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }

        ~Person() // Expression Body Destructor
            => Console.WriteLine("Person object is being destructed");

        public string Name { get; set; }

        public string LastName // Expression Body Property with backing field
        {
            get => this.lastName;
            set => this.lastName = value.Trim();
        }

        public int YearOfBirth { get; set; }

        public int Age // Expression Body Calculation Property
            => DateTime.Now.Year - this.YearOfBirth;

        public override string ToString() // Expression Body Method (type name => expression)
            => $"{this.Name} who was born on {this.YearOfBirth}";

        public void Print() // Expression Body Method with statement
            => Console.WriteLine(ToString());
    }
}