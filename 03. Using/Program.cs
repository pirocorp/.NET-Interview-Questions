global using System.Diagnostics; // Global using directive - imports System.Diagnostics to all files in the project, Implicit global usings works the same way (creates file with global usings when is build)

namespace Using
{
    using System.IO; // Using directive

    using ADto = Using.DTOs.A; // Creating Type alias
    using ADomain = Using.Domain.A; // Creating Type alias

    using static System.Console; // Using static directive

    public static class Program
    {
        public static void Main()
        {
            var a = new ADto();
            var a2 = new ADomain();

            WriteLine("Hello World!");
        }

        // Demo without using statement
        public static void Demo()
        {
            var fs = File.Open("path", FileMode.Open);

            try
            {
                // some operation
            }
            finally
            {
                fs.Dispose();
            }
        }


        public static void DemoWithUsingStatement()
        {
            // using statement define the scope of which IDisposable will be used
            // and in the end of the scope will be disposed
            using var fs = File.Open("path", FileMode.Open);

            // some operations
        }
    }
}