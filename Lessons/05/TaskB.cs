using System;
using System.ComponentModel;
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
        None = 0x0,
        Monday = 0x1,
        Tuesday = 0x2,
        Wednesday = 0x4,
        Thursday = 0x8,
        Friday = 0x10,
        Saturday = 0x20,
        Sunday = 0x40
    }

    public enum OpenClose
    {
        [Description("")]
        NotSpecified,
        [Description("Closed")]
        Closed,
        [Description("Open")]
        Open
    }

    public static class OpeningDaysExtensions
    {
        public static OpenClose GetTodayOpening(this OpeningDays days)
        {
            OpeningDays todaysOpeningDay;
            var todayName = GetTodayName();

            if (Enum.TryParse(todayName, true, out todaysOpeningDay))
            {
                return (days & todaysOpeningDay) > 0
                    ? OpenClose.Open
                    : OpenClose.Closed;
            }

            return OpenClose.NotSpecified;
        }

        private static string GetTodayName()
        {
            return Enum.GetName(typeof(DayOfWeek), DateTime.Today.DayOfWeek) ?? string.Empty;
        }
    }
}