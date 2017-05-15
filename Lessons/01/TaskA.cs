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
        delegate void PrintDateTimeFunnyInfo(DateTime x);

        public static void Run()
        {
            PrintDateTimeFunnyInfo instance;

            instance = M1;
            instance(DateTime.Now);

            instance += M2;
            instance(DateTime.Now);

            instance -= M1;
            instance(DateTime.Now);
        }

        static void M1(DateTime now)
        {
            var noon = now.Date.AddHours(12);

            if (noon < now)
            {
                noon = noon.AddDays(1);
            }

            Console.WriteLine("Next lunch is in {0} minutes", Math.Round((noon - now).TotalMinutes));
        }

        static void M2(DateTime now)
        {
            Console.WriteLine("Today is the day number {0} in this week", (int) now.DayOfWeek + 1);
        }
    }
}