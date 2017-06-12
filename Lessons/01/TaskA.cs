using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "PrintDateTimeFunnyInfo" with DateTime type as a parameter without any return value.
    /// Create a method (M1) with the same signature like the delegate that prints the number of minutes to lunch (at noon).
    /// E.g. For 11:26 it prints "Next lunch is in 34 minutes".
    /// Create a method (M2) with the same signature like the delegate that prints the number of current day of week.
    /// E.g. For Monday it prints "today is the day number 2 in this week".
    /// Create a delegate instance for M1 and invoke it for current date and time.
    /// Create a delegate instance for M1 + M2 and invoke it for current date and time.
    /// Create a delegate instance for M1 + M2 - M1 and invoke it for current date and time.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            M2(DateTime.Today.AddDays(1).AddMinutes(23));
        }

        public delegate void PrintDateTimeFunnyInfo(DateTime time);

        public static void M1(DateTime time) {
            var minutesToNextLunch = 0;
            DateTime nextLunchTime;
            if (time.Hour > 11)
            {
                nextLunchTime = DateTime.Today.AddDays(1).AddHours(12);
                minutesToNextLunch = (24 - (time.Hour - nextLunchTime.Hour)) * 60 - time.Minute;
            } else
            {
                nextLunchTime = DateTime.Today.AddHours(12);
                minutesToNextLunch = (nextLunchTime.Hour - time.Hour) * 60 - time.Minute;
            }
            Console.WriteLine($"Next lunch is in {minutesToNextLunch} minutes");   
        }

        public static void M2(DateTime time)
        {
            var dayNumber = (int) time.DayOfWeek;
            Console.WriteLine($"Today is the day number {dayNumber} in this week");
        }
    }
}