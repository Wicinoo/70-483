namespace Lessons._05
{
    using System;

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

        public enum ShopStatus
        {
            Opened,
            Closed
        }
    }

    public static class EnumExtensions
    {
        public static string GetTodayOpening(this TaskB.OpeningDays value)
        {
            var today = (int)DateTime.Now.DayOfWeek;
            if ((today & (int)value) == today)
            {
                return TaskB.ShopStatus.Opened.ToString();
            }
            return TaskB.ShopStatus.Closed.ToString();

        }
    }
}