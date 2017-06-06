using System;
using System.Diagnostics.CodeAnalysis;

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
            PrintDateTimeFunnyInfo instance1 = M1;
            instance1(DateTime.Now);
            Console.WriteLine();

            PrintDateTimeFunnyInfo instance2 = M1;
            instance2 += M2;
            instance2(DateTime.Now);
            Console.WriteLine();

            PrintDateTimeFunnyInfo instance3 = M1;
            instance3 += M2;
            instance3 -= M1;
           instance3(DateTime.Now);
            Console.WriteLine();
        }

        private static void M1(DateTime dateTime)
        {
            var minutesToLunch = GetMinutesToLunch(dateTime);
            Console.WriteLine($"Next lunch is in {minutesToLunch} minutes");
        }

        private static int GetMinutesToLunch(DateTime dateTime)
        {
            var isPastNoon = dateTime.TimeOfDay > new TimeSpan(12, 00, 00);
            var incrementDay = isPastNoon ? 1 : 0;
            var nextNoon = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + incrementDay, 12, 0, 0); 

            return (int)(nextNoon - dateTime).TotalMinutes;
        }

        private static void M2(DateTime dateTime)
        {
            var dayOfWeek = GetDayOfWeek(dateTime);
            Console.WriteLine($"today is the day number {dayOfWeek} in this week");
        }

        private static int GetDayOfWeek(DateTime dateTime)
        { // Monday = 2
            return (int)dateTime.DayOfWeek + 1;
        }
    }
}