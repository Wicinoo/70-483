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
            Console.WriteLine("TaskA:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("M1:");
            PrintDateTimeFunnyInfo m1 = new PrintDateTimeFunnyInfo(M1);
            m1(DateTime.Now);

            Console.WriteLine("M1 + M2:");

            PrintDateTimeFunnyInfo m1m2 = new PrintDateTimeFunnyInfo(M1);
            m1m2 += new PrintDateTimeFunnyInfo(M2);
            m1m2(DateTime.Now);

            Console.WriteLine("M1 + M2 - M1:");

            PrintDateTimeFunnyInfo m1m2m1 = new PrintDateTimeFunnyInfo(M1);
            m1m2m1 += new PrintDateTimeFunnyInfo(M2);
            m1m2m1 -= new PrintDateTimeFunnyInfo(M1);
            m1m2m1(DateTime.Now);
            Console.WriteLine("---------------------------------------");
        }

        static void M1(DateTime date)
        {
            DateTime nextLunch = date.Hour > 12 ? date.Date.AddDays(1) : date.Date;
            nextLunch = new DateTime(nextLunch.Year, nextLunch.Month, nextLunch.Day, 12, 0, 0);
            Console.WriteLine("Minutes remaining till lunch: " + (nextLunch - date).TotalMinutes.ToString("0.00")); ;
        }

        static void M2(DateTime date)
        {
            Console.WriteLine("Today is " + date.DayOfWeek.ToString());
        }
    }

    delegate void PrintDateTimeFunnyInfo(DateTime date);
}
