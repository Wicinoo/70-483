using System;

namespace Lessons._05
{
    /// <summary>
    /// * Declare an flagged enum type OpeningDays with all days in week. 
    /// * Declare an extension method GetTodayOpening() for the type OpeningDays.
    /// It returns Opened if a value contains today, otherwise Closed.
    /// * Opened and Closed are values of an another custom enum type.
    /// </summary>
    public static class ExtensionMethods
    {
        public static string GetTodayOpening(this OpeningDays openingDays)
        {
            var today = DateTime.Today.DayOfWeek.ToString();
            var openingDayOfWeek = (OpeningDays)Enum.Parse(typeof(OpeningDays), today, true);

            return openingDays.HasFlag(openingDayOfWeek) 
                ? ShopState.Opened.ToString()
                : ShopState.Closed.ToString();
        }
    }

    [Flags]
    public enum OpeningDays
    {
        None = 16,
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 4,
        Friday = 6,
        Saturday = 8,
        Sunday = 12
    }

    public enum ShopState
    {
        Opened,
        Closed
    }

    public class TaskB
    {
        public static void Run()
        {
            Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening()}");
            Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening()}");
            Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening()}");
            Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening()}");
            Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening()}");
        }
    }
}