namespace Checked
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var result = 0;
            try
            {
                // Enables check for overflow exception
                checked
                {
                    var twoBillion = 2_000_000_000;
                    result = twoBillion + twoBillion;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("the result is: " + result);
        }
    }
}
