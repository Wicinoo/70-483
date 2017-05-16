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
        private delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

        public static void Run()
        {
            PrintDateTimeFunnyInfo firstInstance = M1;
            firstInstance(DateTime.Now);

            PrintDateTimeFunnyInfo secondInstance = M1;
            secondInstance += M2;
            secondInstance(DateTime.Now);

            PrintDateTimeFunnyInfo thirdInstance = M1;
            thirdInstance += M2;
            thirdInstance -= M1;
            thirdInstance(DateTime.Now);
        }

        public static void M1(DateTime dateTime)
        {
            var nextNoon = dateTime.Date;
            if (dateTime.Hour > 12)
            {
                nextNoon = nextNoon.AddDays(1);
            }
            nextNoon = nextNoon.AddHours(12);
            var timeSpan = nextNoon - dateTime;
            Console.WriteLine($"Next lunch is in {timeSpan.TotalMinutes} minutes");
        }

        public static void M2(DateTime dateTime)
        {
            Console.WriteLine($"today is the day number {(int)dateTime.DayOfWeek} in this week");
        }
    }
}