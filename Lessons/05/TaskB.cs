using System;
using System.Reflection;

namespace Lessons._05
{
    /// <summary>
    /// * Declare an flagged enum type OpeningDays with all days in week. 
    /// * Declare an extension method GetTodayOpening() for the type OpeningDays.
    /// It returns Opened if a value contains today, otherwise Closed.
    /// * Opened and Closed are values of an another custom enum type.
    /// </summary>
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

    [Flags]
    public enum OpeningDays
    {
        None = 0,
        Monday = 1 << 0,
        Tuesday = 1 << 1,
        Thursday = 1 << 2,
        Wednesday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6
    }

    public enum Availability
    {
        Open,
        Closed
    }

    public static class OpeningDaysExtenstions
    {
        public static Availability GetTodayOpening(this OpeningDays openingDays)
        {
            var today = DateTime.Today.DayOfWeek.ToString();
            var openingDaysToday = (OpeningDays) Enum.Parse(typeof (OpeningDays), today);

            return openingDays.HasFlag(openingDaysToday) ? Availability.Open : Availability.Closed;
        }
    }
}