namespace IDisposable
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            // using statement is just syntactic sugar for try/finally block
            // finally block ensures that Dispose method should be called
            // no matter exception is thrown or not
            using var fileReader = new FileReader("input.txt");

            var line1 = fileReader.ReadLine();
            var line2 = fileReader.ReadLine();

            Console.WriteLine(line1);
            Console.WriteLine(line2);

            // GC Demo
            SomeMethod();
            GC.Collect();
        }

        public static void SomeMethod()
        {
            var john = new Person("John");
        }
    }
}
