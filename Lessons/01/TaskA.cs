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
        public delegate void PrintDateTimeFunnyInfo(DateTime date);

        public static void M1(DateTime dateTime)
        {
            var lunchTime = dateTime.Date.Add(TimeSpan.Parse("12:00:00"));

            if (lunchTime < dateTime)
            {
                lunchTime = lunchTime.AddDays(1);
            }

            Console.WriteLine($"Next lunch is in {(int)lunchTime.Subtract(dateTime).TotalMinutes} minutes.");
        }

        public static void M2(DateTime dateTime)
        {
            Console.WriteLine($"Today is the day number {(int)dateTime.DayOfWeek} in this week.");
        }

        public static void Run()
        {
            PrintDateTimeFunnyInfo lunchPrinter = M1;
            lunchPrinter(DateTime.Now);

            var funnyPrinter = lunchPrinter + M2;
            funnyPrinter(DateTime.Now);

            var funniestPrinter = funnyPrinter - M1;
            funniestPrinter(DateTime.Now);
        }
    }
}