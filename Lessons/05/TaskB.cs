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
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    public static class OpeningDaysExtensions
    {
        public static string GetTodayOpening(this OpeningDays openingday)
        {
            if (openingday == 0 || !openingday.HasFlag(GetToday()))
            {
                return "Closed";
            }

            return "Opened";
        }

        public static OpeningDays GetToday()
        {
            switch (DateTime.Today.DayOfWeek)
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