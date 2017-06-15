using System;

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
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }

    public enum Status
    {
        Opened,
        Closed
    }

    public static class Extensions
    {
        public static Status GetTodayOpening(this OpeningDays openingDays)
        {
            var dayOfWeek = DateTime.Today.DayOfWeek;

            var openingDay = MapDayOfWeek(dayOfWeek);

            return (openingDays & openingDay) == openingDay ? Status.Opened : Status.Closed;
        }

        private static OpeningDays MapDayOfWeek(DayOfWeek dayOfWeek)
        {
            return (OpeningDays) Enum.Parse(typeof (OpeningDays), dayOfWeek.ToString());
        }
    }
}