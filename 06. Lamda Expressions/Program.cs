namespace LambdaExpressions
{
    public static class Program
    {
        private static Func<int, DateTime, string, decimal> someFunc;
        private static Action<string, string, bool> someAction;

        public static void Main()
        {
            var arr = new[] { 1, 2, 3 };

            Func<int, bool> func = n => n % 2 == 0;

            // Lambda Expressions (Anonymous Functions) (p1, p2) => expression
            IsAny(arr, number => number > 10);
            IsAny(arr, number => number % 2 == 0);
        }

        public static bool IsAny(
            IEnumerable<int> numbers,
            Predicate<int> predicate)
        {
            foreach (var number in numbers)
            {
                if (predicate(number))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
