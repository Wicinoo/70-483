using System;

namespace Lessons._05
{
    /// <summary>
    /// * Declare an flagged enum type OpeningDays with all days in week. 
    /// * Declare an extension method GetTodayOpening() for the type OpeningDays.
    /// It returns Opened if a value contains today, otherwise Closed.
    /// * Opened and Closed are values of an another custom enum type.
    /// </summary>
    public static class TaskB
    {
        public static void Run()
        {
            Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening()}");
            Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening()}");
            Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening()}");
            Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening()}");
            Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening()}");
        }

        public enum OpeningDays
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            None
        }
        public enum OpeningDayStatus
        {
            NotDefined = 0,
            Closed,
            Opened
        }

        public static OpeningDayStatus GetTodayOpening(this OpeningDays openingDays)
        {
            DayOfWeek today;

            var openingDayStatus = OpeningDayStatus.Closed;

            if (Enum.TryParse<DayOfWeek>(openingDays.ToString(), out today))
            {
                openingDayStatus = DateTime.Today.DayOfWeek == today ? OpeningDayStatus.Opened : OpeningDayStatus.Closed;
            }

            return openingDayStatus;

        }
    }
}