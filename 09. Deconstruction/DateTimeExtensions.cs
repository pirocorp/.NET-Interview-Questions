namespace Deconstruction
{
    using System;

    public static class DateTimeExtensions
    {
        // Extension Deconstruct Method
        public static void Deconstruct(
            this DateTime date,
            out int year,
            out int month,
            out int day)
        {
            year = date.Year;
            month = date.Month;
            day = date.Day;
        }
    }
}
