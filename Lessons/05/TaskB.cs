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
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 4,
        Friday = 8,
        Saturday = 16,
        Sunday = 32,
        None = 64
    };

    public enum Status
    {
        Opened,
        Closed
    };

    public static class OpeningExtension
    {
        public static Status GetTodayOpening(this OpeningDays days)
        {
            var today = GetToday();

            return days.HasFlag(today) ? Status.Opened : Status.Closed;
        }

        private static OpeningDays GetToday()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return OpeningDays.Sunday;
                case DayOfWeek.Monday:
                    return OpeningDays.Monday;
                case DayOfWeek.Tuesday:
                    return OpeningDays.Tuesday;
                case DayOfWeek.Wednesday:
                    return OpeningDays.Wednesday;
                case DayOfWeek.Thursday:
                    return OpeningDays.Thursday;
                case DayOfWeek.Friday:
                    return OpeningDays.Friday;
                case DayOfWeek.Saturday:
                    return OpeningDays.Saturday;
                default:
                    return OpeningDays.None;
            }
        }
    }
}