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
        delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

        public static void Run()
        {
            PrintDateTimeFunnyInfo delegateInstanceForM1 = M1;
            Console.WriteLine("instance for M1 and invoke it for current date and time: ");
            delegateInstanceForM1(DateTime.Now);

            Console.WriteLine("=======================");

            PrintDateTimeFunnyInfo delegateInstanceForM1M2 = M1;
            delegateInstanceForM1M2 += M2;
            Console.WriteLine("instance for M1 + M2 and invoke it for current date and time.: ");
            delegateInstanceForM1M2(DateTime.Now);

            Console.WriteLine("=======================");

            PrintDateTimeFunnyInfo delegateInstanceForM1M2MinusM1 = M1;
            delegateInstanceForM1M2MinusM1 += M2;
            delegateInstanceForM1M2MinusM1 -= M1;
            Console.WriteLine("instance for M1 + M2 - M1 and invoke it for current date and time.: ");
            delegateInstanceForM1M2MinusM1(DateTime.Now);
        }


        private static void M1(DateTime dateTime)
        {
            var nextNoon = GetNextNoon(dateTime);
            var timeToLunch = nextNoon - dateTime;

            Console.WriteLine($"Next Lunch is in {timeToLunch.TotalMinutes}.");
        }

        private static void M2(DateTime dateTime)
        {
            int numberOfDayInWeek = ((int)DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;

            Console.WriteLine($"today is the day number {numberOfDayInWeek} in this week");
        }

        private static DateTime GetNextNoon(DateTime dateTime)
        {
            var todaysNoon = DateTime.Today + new TimeSpan(12, 0, 0);

            return dateTime < todaysNoon ? todaysNoon : todaysNoon.AddDays(1);
        }
    }
}