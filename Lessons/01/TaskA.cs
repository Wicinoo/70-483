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

        public static void Run()
        {
            PrintDateTimeFunnyInfo minutesToLunch = M1;

            minutesToLunch(DateTime.Now);

            PrintDateTimeFunnyInfo dayOfWeek = M2;

            dayOfWeek(DateTime.Now);

            PrintDateTimeFunnyInfo d = M1;

            d += M2;
            d(DateTime.Now);

            d -= M1;

            d(DateTime.Now);
        }

        public static void M1(DateTime date)
        {
            TimeSpan span = new DateTime(date.Year, date.Month, (date.Hour >= 12 ? date.Day + 1 : date.Day), 12, 0, 0) - date;

            Console.WriteLine(String.Format("Next lunch is in {0:#} minutes.", span.TotalMinutes));
        }

        public static void M2(DateTime date)
        {
            Console.WriteLine(String.Format("Today is the day number {0} in this week.", (int)date.DayOfWeek + 1));
        }
    }
}