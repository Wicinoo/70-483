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
        delegate void PrintDateTimeFunnyInfo(DateTime d);

        public static void Run()
        {
            PrintDateTimeFunnyInfo m1 = M1;
            m1(DateTime.Now);

            PrintDateTimeFunnyInfo m12 = M1;
            m12 += M2;       
            m12(DateTime.Now);

            PrintDateTimeFunnyInfo m121 = M1;
            m121 += M2;
            m121 -= M1;
            m121(DateTime.Now);
        }

        public static void M1(DateTime d) {
            var lunchTime = new TimeSpan(12,0,0);
            var currTime = d.TimeOfDay;
             TimeSpan timeToLunch = currTime <= lunchTime ? lunchTime - currTime : lunchTime.Add(new TimeSpan(1,0,0,0)) - currTime;

            Console.WriteLine(timeToLunch.TotalMinutes);
        }

        public static void M2(DateTime d) {
            Console.WriteLine(d.DayOfWeek);
        }                                    
    }
}