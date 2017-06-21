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
        [Flags]
        public enum OpeningDays
        {
            Monday = 0x0,
            Tuesday = 0x1,
            Wednesday = 0x2,
            Thursday = 0x4,
            Friday = 0x8,
            Saturday = 0x10,
            Sunday = 0x20,
            None = 0x40
        }

        public enum OpenedAndClosed
        {
            Opened = 0x0,
            Closed = 0x1,
        }

        public static OpenedAndClosed GetTodayOpening(this OpeningDays openingDaysFlags)
        {
            OpeningDays day;
            Enum.TryParse<OpeningDays>(DateTime.Today.DayOfWeek.ToString(), out day);
            return (day & openingDaysFlags) > 0 ? OpenedAndClosed.Opened : OpenedAndClosed.Closed;
        }

        public static void Run()
        {
            //Console.WriteLine(GetTodayOpening(OpeningDays.Friday).ToString());
            //Console.WriteLine(GetTodayOpening(OpeningDays.Wednesday).ToString());
            Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening()}");
            Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening()}");
            Console.WriteLine($"Only Wednesdays: {OpeningDays.Wednesday.GetTodayOpening()}");
            Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening()}");
            Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening()}");
            Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening()}");
        }
    }

}