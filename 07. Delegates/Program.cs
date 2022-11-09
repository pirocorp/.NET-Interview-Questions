namespace Delegates
{
    using System;

    public static class Program
    {
        // A delegate is a Type whose instances hold a reference to a method (or methods)
        // with particular parameters and return type
        private delegate string ProcessString(string input); // Func<string, string>

        private delegate void Print(string input);

        public static void Main()
        {
            // Variables of ProcessString delegate type
            ProcessString processString1 = TrimTo5Letters;
            ProcessString processString2 = ToUpper;

            Console.WriteLine(processString1("Hello world!"));
            Console.WriteLine(processString2("Hello world!"));

            Print print1 = text => Console.WriteLine(text.ToUpper());
            Print print2 = text => Console.WriteLine(text.ToLower());
            Print print3 = text => Console.WriteLine(text.Substring(0, 3));

            // We can store more than one function in one variable of delegate type
            // A delegate variable that holds references to more than one function
            // is called multicast delegate
            var multicast = print1 + print2;
            multicast += print3;
            multicast("test");
        }

        private static string TrimTo5Letters(string input)
        {
            return input.Substring(0, 5);
        }

        private static string ToUpper(string input)
        {
            return input.ToUpper();
        }
    }
}