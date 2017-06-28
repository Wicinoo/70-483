using System;
using Rhino.Mocks.Constraints;

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
        Saturday = 64, 
    }

    public static class Extendsions
    {
        public static OpenedClosed GetTodayOpening(this OpeningDays openingDay)
        {
            return openingDay.HasFlag(DateTime.Today.DayOfWeek.ToOpeningDays()) ? OpenedClosed.Opened : OpenedClosed.Closed;
        }

        public static OpeningDays ToOpeningDays(this DayOfWeek day)
        {
            return (OpeningDays) Enum.Parse(typeof (OpeningDays), day.ToString());
        }
    }

    public enum OpenedClosed
    {
        Unknowns, 
        Opened, 
        Closed
    }
}