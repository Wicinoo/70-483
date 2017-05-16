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
        public delegate void PrintDateTimeFunnyInfo(DateTime d);

        public static void Run()
        {
            //question1
            PrintDateTimeFunnyInfo m1 = M1;
            m1(DateTime.Now);

            PrintDateTimeFunnyInfo m2 = M2;
            //m2(DateTime.Now);

            //question 2
            PrintDateTimeFunnyInfo m3 = M1;
            m3 += m2;
            m3(DateTime.Now);

            //Console.WriteLine(m3.GetInvocationList().GetLength(0));

            //question 3
            PrintDateTimeFunnyInfo m4 = M1;
            m4 += m2;
            //Console.WriteLine(m4.GetInvocationList().GetLength(0));
            m4 -= m1;
            //Console.WriteLine(m4.GetInvocationList().GetLength(0));
            m4(DateTime.Now);
        }

        public static void M1(DateTime d)
        {
            var tommorowsLunch = new DateTime(d.Year, d.Month, d.Day + 1, 12, 0, 0);
            var todaysLunch = new DateTime(d.Year, d.Month, d.Day, 12, 0, 0);

            if (d > todaysLunch)
            {
                Console.WriteLine("Next Lunch is in {0} minutes", (tommorowsLunch - d).TotalMinutes);
            }
            else
            {
                Console.WriteLine("Next Lunch is in {0} minutes", (todaysLunch - d).TotalMinutes);
            }
        }

        public static void M2(DateTime d)
        {
            Console.WriteLine("today is day number {0} in this week", (int)d.DayOfWeek + 1);
        }
    }
}