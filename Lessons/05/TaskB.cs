using System;
using Task5Extensions;
using static Lessons._05.TaskB;

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
        public enum ShopState
        {
            Opened,
            Closed
        }

        [Flags]
        public enum OpeningDays
        {
            None=0,
            Monday = 1,
            Tuesday=2,
            Wednesday=4,
            Thursday=8,
            Friday=16,
            Saturday=32,
            Sunday=64
        }

    
        public static void Run()
        {
            Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening()}");
            Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening()}");
            Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening()}");
            Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening()}");
            Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening()}");
        }
    }


}

namespace Task5Extensions
{
    public static class EnumExtensions
    {
        public static Lessons._05.TaskB.ShopState GetTodayOpening(this Lessons._05.TaskB.OpeningDays day)
        {
            OpeningDays flagValueOpeningDay;
            Enum.TryParse<OpeningDays>(DateTime.Today.DayOfWeek.ToString(), out flagValueOpeningDay);
            if (day.HasFlag(flagValueOpeningDay))
            {
                return Lessons._05.TaskB.ShopState.Opened;
            }

            return Lessons._05.TaskB.ShopState.Closed;
        }
    }

}