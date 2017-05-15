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
        private const int LunchTimeInHours = 12;

        delegate void PrintDatetimeFunnyInfo(DateTime time);

        public static void Run()
        {
            PrintDatetimeFunnyInfo m1 = M1;
            m1(DateTime.Now);

            PrintDatetimeFunnyInfo both = M1;
            both += M2;
            both(DateTime.Now);

            PrintDatetimeFunnyInfo bothMinusFirst = M1;
            bothMinusFirst += M2;
            bothMinusFirst -= M1;
            bothMinusFirst(DateTime.Now);
        }

        private static void M1(DateTime time)
        {
            Console.WriteLine(GetNextLunchMessage(GetTimeTillLunch(time)));
        }

        private static void M2(DateTime time)
        {
            Console.WriteLine($"today is the day number {(int)DateTime.Today.DayOfWeek} in this week");
        }

        private static string GetNextLunchMessage(TimeSpan howLong)
        {
            return $"Next lunch is in {Math.Floor(howLong.TotalMinutes)} minutes";
        }

        private static TimeSpan GetTimeTillLunch(DateTime time)
        {
            return GetNextNoon(time) - time;
        }

        private static DateTime GetNextNoon(DateTime time)
        {
            return DateTime.Today.AddHours(time.Hour >= LunchTimeInHours ? LunchTimeInHours * 3 : LunchTimeInHours);
        }
    }
}