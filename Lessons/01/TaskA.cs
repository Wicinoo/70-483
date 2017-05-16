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
    public static class TaskA
    {
        private static TimeSpan AtNoon = new TimeSpan(12, 0, 0);

        public delegate void PrintDateTimeFunnyInfo(DateTime parameter);

        public static void M1(DateTime parameter)
        {
            int minutesRemain = (int)parameter.TimeOfDay.TotalMinutes < (int)AtNoon.TotalMinutes ? (int)AtNoon.TotalMinutes - (int)parameter.TimeOfDay.TotalMinutes : ((int)AtNoon.TotalMinutes * 3) - (int)parameter.TimeOfDay.TotalMinutes;

            Console.WriteLine("Next lunch is in {0} minutes", minutesRemain);
        }

        public static void M2(DateTime parameter)
        {
            Console.WriteLine("today is the day number {0} in this week", parameter.DayOfWeek);
        }

        public static void Run()
        {
            /// Create a delegate instance for M1 and invoke it for current date and time.
            PrintDateTimeFunnyInfo d1 = M1;
            d1(DateTime.Now);

            /// Create a delegate instance for M1 + M2 and invoke it for current date and time.
            PrintDateTimeFunnyInfo d2 = M1;
            d2 += M2;
            d2(DateTime.Now);

            /// Create a delegate instance for M1 + M2 - M1 and invoke it for current date and time.
            PrintDateTimeFunnyInfo d3 = M1;
            d3 += M2;
            d3 -= M1;
            d3(DateTime.Now);

        }
    }
}