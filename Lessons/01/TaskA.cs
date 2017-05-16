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
            PrintDateTimeFunnyInfo instance1 = M1;

            instance1.Invoke(DateTime.Now);

            PrintDateTimeFunnyInfo instance2 = M1;

            instance2 += M2;

            instance2.Invoke(DateTime.Now);

            PrintDateTimeFunnyInfo instance3 = M1;

            instance3 += M2;

            instance3 -= M1;

            instance3.Invoke(DateTime.Now);
        }

        private static void M1(DateTime time)
        {
            if (time < DateTime.Today.AddHours(12))
            {
                Console.WriteLine("Next lunch is in {0} minutes", (int) (DateTime.Today.AddHours(12) - time).TotalMinutes);
            }
            else
            {
                Console.WriteLine("Next lunch is in {0} minutes", (int) (DateTime.Today.AddDays(1).AddHours(12) - time).TotalMinutes);
            }
        }

        private static void M2(DateTime time)
        {
            Console.WriteLine("today is the day number {0} in this week", (int) time.DayOfWeek + 1);
        }

        private delegate void PrintDateTimeFunnyInfo(DateTime time);
    }

 
}