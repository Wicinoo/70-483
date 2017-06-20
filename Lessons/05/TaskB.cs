using System;
using System.Linq;

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
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
            {
                RunForDay(day.GetAsOpeningDays());
            }
        }

        public static void RunForDay(OpeningDays today)
        {
            Console.WriteLine($"Today is: {today}");
            Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening(today)}");
            Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening(today)}");
            Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening(today)}");
            Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening(today)}");
            Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening(today)}");
            Console.WriteLine($"Always open: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday | OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening(today)}");
            Console.WriteLine();
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

    public enum OpeningStatus
    {
        Closed = 0, 
        Open
    }

    public static class Extensions
    {
        public static OpeningStatus GetTodayOpening(this OpeningDays openingDays, OpeningDays today)
        {
            if ((openingDays & today) == today)
            {
                return OpeningStatus.Open;
            }
            return OpeningStatus.Closed;
        }

        public static OpeningDays GetAsOpeningDays(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return OpeningDays.Monday;
                case DayOfWeek.Tuesday: return OpeningDays.Tuesday;
                case DayOfWeek.Wednesday: return OpeningDays.Wednesday;
                case DayOfWeek.Thursday: return OpeningDays.Thursday;
                case DayOfWeek.Friday: return OpeningDays.Friday;
                case DayOfWeek.Saturday: return OpeningDays.Saturday;
                case DayOfWeek.Sunday: return OpeningDays.Sunday;
                default: throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Invalid DayOfWeek.");
            }
        }
    }

}