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
            DateTime currentTime = DateTime.Now;
            PrintDateTimeFunnyInfo first = M1;
            first(currentTime);

            PrintDateTimeFunnyInfo second = M1;
            second += M2;
            second(currentTime);

            PrintDateTimeFunnyInfo third = M1;
            third += M2;
            third -= M1;
            third(currentTime);
        }

        public static void M1(DateTime date)
        {
            //print number of minutes
            DateTime nextLunch = DateTime.Today.AddHours(12);
            if (date.Hour >= 12 && date.Minute > 0) {
                nextLunch = nextLunch.AddDays(1);
            }

            TimeSpan ts = nextLunch.Subtract(date);
            Console.WriteLine("Next lunch is in {0} minutes", ts.TotalMinutes);
        }

        public static void M2(DateTime date)
        {
            Console.WriteLine("today is the day number {0} in this week", (int) date.DayOfWeek);
        }
    }
}