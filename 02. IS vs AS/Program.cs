namespace IS_vs_AS
{
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            object text = "hello";

            bool isString = text is string;
            bool isInt = text is int;

            // as can be used only with nullable types, because if it fails null will be returned

            string? textAsString = text as string; // hello
            List<int>? list = text as List<int>; // null
            // int number = text as int // Invalid null can't be assigned to int
            List<int> list2 = (List<int>)text; // InvalidCastException
        }
    }
}
