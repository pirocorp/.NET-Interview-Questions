namespace IDisposable
{
    using System;

    public class Person
    {
        public string Name { get; }

        public Person(string name) => this.Name = name;

        // The destructor, the finalizer and the Finalize method are the same things.
        // The destructor gets changed to the Finalize method during the compilation
        // The Finalize method is called on an object when it is being cleaned up by the GC
        ~Person()
        {
            Console.WriteLine($"Person {this.Name} is being destructed");
        }
    }
}
