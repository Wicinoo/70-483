using System;
using Rhino.Mocks.Impl;

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
        public delegate void PrintDateTimeFunnyInfo(DateTime inputDateTime);
        public static void Run()
        {
            Console.WriteLine("M1");
            var printableMethods = new PrintableMethods();
            PrintDateTimeFunnyInfo printM1 = printableMethods.M1;
            printM1(DateTime.Now);

            Console.WriteLine("M1 + M2");
            PrintDateTimeFunnyInfo printM1M2 = printableMethods.M1;
            printM1M2 += printableMethods.M2;
            printM1M2(DateTime.Now);

            Console.WriteLine("M1 + M2 - M1");
            PrintDateTimeFunnyInfo printM1M2WithoutM1 = printableMethods.M1;
            printM1M2WithoutM1 += printableMethods.M2;
            printM1M2WithoutM1 -= printableMethods.M1;
            printM1M2WithoutM1(DateTime.Now);

        }
    }

    public class PrintableMethods
    {
        public void M1(DateTime inputDateTime)
        {
            DateTime lunchDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
            var lunch = lunchDate.Subtract(inputDateTime);
            Console.WriteLine("Next lunch is in {0} minutes", lunch.Minutes);
        }

        public void M2(DateTime inputDateTime)
        {
            Console.WriteLine("Today is the day number {0} in this week", (int) inputDateTime.DayOfWeek);
        }
    }
}