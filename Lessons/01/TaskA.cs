using System;

namespace Lessons._01
{
    using FluentAssertions;

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
        public delegate void PrintDateTimeFunnyInfo(DateTime d);

        public static void Run()
        {
            PrintDateTimeFunnyInfo printDateInfo = M1;
            //M1
            printDateInfo(DateTime.Now);

            printDateInfo += M2;
            //M1 + M2
            printDateInfo(DateTime.Now);

            printDateInfo -= M1;
            // M1 + M2 - M1
            printDateInfo(DateTime.Now);

        }

        public static void M1(DateTime d)
        {
            bool isAfterLunch = (d.Hour >= 12);
            DateTime noon = new DateTime(d.Year, d.Month, d.Day, 12, 0, 0);

            if (isAfterLunch)
            {
                noon = noon.AddDays(1);
            }

            Console.WriteLine("Next lunch is in {0} minutes", (int)noon.Subtract(d).TotalMinutes);
        }

        public static void M2(DateTime d)
        {
            //dirty hack to get day of week incremented by one.
            Console.WriteLine("today is the day number {0} in this week", (int)d.AddDays(1).DayOfWeek);
        }
    }
}