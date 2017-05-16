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
        public delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

        public static void Run()
        {
            PrintDateTimeFunnyInfo d1 = M1;

            d1(DateTime.Now);

            PrintDateTimeFunnyInfo d2 = M1;

            d2 += M2;

            d2(DateTime.Now);

            PrintDateTimeFunnyInfo d3 = M1;

            d3 += M2;

            d3 -= M1;

            d3(DateTime.Now);
        }

        public static void M1(DateTime fromDateTime)
        {
            var fromTime = fromDateTime.TimeOfDay;

            var lunchTime = DateTime.Parse("12:00").TimeOfDay;

            var toNextLunchTime = fromTime < lunchTime
                ? lunchTime - fromTime
                : lunchTime - fromTime + TimeSpan.FromDays(1);

            Console.Out.WriteLine($"Next lunch is in {toNextLunchTime.TotalMinutes.ToString("####")} minutes.");
        }

        public static void M2(DateTime dateTime)
        {
            var dayOfWeek = (int) dateTime.DayOfWeek + 1;

            Console.Out.WriteLine($"Today is the day number {dayOfWeek} in this week.");
        }
    }
}