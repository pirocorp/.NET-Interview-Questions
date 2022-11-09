namespace Tuple_vs_Value_Tuple
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            // Tuple backed by System.ValueTuple
            (int Count, string Text) tuple1 = (1, "aaa");

            var count = tuple1.Count;
            var text = tuple1.Text;

            // System.Tuple
            var tuple2 = new Tuple<int, string>(1, "aaa");
            var tuple3 = Tuple.Create(1, "aaa");

            // Tuples are immutable
            // tuple2.Item1 = 5;

            // ValueTuple
            var valueTuple = new ValueTuple<int, string>(33, "cccc");
            var valueTuple2 = tuple1;
            var valueTuple3 = (Number: 5, Text: "Text");

            // ValueTuples are mutable
            valueTuple2.Count = 55;
        }
    }
}
