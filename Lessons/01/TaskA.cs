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
        private delegate void PrintDateTimeFunnyInfo(DateTime date);

        public static void Run()
        {
            var date = DateTime.Now;

            PrintDateTimeFunnyInfo m1 = M1;
            PrintDateTimeFunnyInfo m12 = M1;
            m12 += M2;

            PrintDateTimeFunnyInfo m121 = M1;
            m121 += M2;
            m121 -= M1;

            Console.WriteLine("m1");
            m1.Invoke(date);
            Console.WriteLine("m12");
            m12.Invoke(date);
            Console.WriteLine("m121");
            m121.Invoke(date);

            M1(date);
        }

        public static void M1(DateTime date)
        {
            var lunch = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);

            var span = lunch > date ? lunch - date : date.AddDays(1) - lunch;

            Console.WriteLine($"Next lunch is in {span.TotalMinutes} minutes");
        }

        public static void M2(DateTime date)
        {
            Console.WriteLine($"today is the day number {(int)date.DayOfWeek} in this week");
        }
    }
}