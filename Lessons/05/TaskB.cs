using System;
using System.Collections.Generic;

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

    public enum Status
    {
        Opened,
        Closed
    }

    static class DurationExtensions
    {
        private static IDictionary<DayOfWeek, OpeningDays> _mapping = new Dictionary<DayOfWeek, OpeningDays>
        {
            { DayOfWeek.Monday, OpeningDays.Monday },
            { DayOfWeek.Tuesday, OpeningDays.Tuesday },
            { DayOfWeek.Wednesday, OpeningDays.Wednesday },
            { DayOfWeek.Thursday, OpeningDays.Thursday },
            { DayOfWeek.Friday, OpeningDays.Friday },
            { DayOfWeek.Saturday, OpeningDays.Saturday },
            { DayOfWeek.Sunday, OpeningDays.Sunday }
        };

        public static Status GetTodayOpening(this OpeningDays openingDays)
        {
            var today = _mapping[DateTime.Today.DayOfWeek];
            return openingDays.HasFlag(today) ? Status.Opened : Status.Closed;
        }
    }
}