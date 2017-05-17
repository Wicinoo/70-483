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
        public delegate void PrintDateTimeFunnyInfo(DateTime asAt);

        public static void Run()
        {
            PrintDateTimeFunnyInfo testM1 = M1;
            testM1(DateTime.Now);

            Console.WriteLine();

            PrintDateTimeFunnyInfo testM1M2 = M1;
            testM1M2 += M2;
            testM1M2(DateTime.Now);

            Console.WriteLine();

            PrintDateTimeFunnyInfo testM1M2M1 = M1;
            testM1M2M1 += M2;
            testM1M2M1 -= M1;
            testM1M2M1(DateTime.Now);
        }

        public static void M1(DateTime asAt)
        {
            var noon = DateTime.Today.AddHours(12);
            var minsToLunch = asAt >= noon ? (noon.AddDays(1) - asAt).TotalMinutes : (noon - asAt).TotalMinutes;

            Console.WriteLine($"Next lunch is in {Math.Round(minsToLunch,0)} minutes");            
        }

        public static void M2(DateTime asAt)
        {
            Console.WriteLine($"Today is the day number {(int)asAt.DayOfWeek} in this week");
        }
    }
}