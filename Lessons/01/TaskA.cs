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

    public delegate void PrintDateTimeFunnyInfo(DateTime dateTime);
    public class TaskA
    {
        public static void Run()
        {
            PrintDateTimeFunnyInfo funnyInfo = PrintMinutesToLunch;
            funnyInfo(DateTime.Now);

            funnyInfo += NumberOfCurrentDay;
            funnyInfo(DateTime.Now);

            funnyInfo -= PrintMinutesToLunch;
            funnyInfo(DateTime.Now);
        }

        public static void PrintMinutesToLunch(DateTime dateTime)
        {
            int day = (dateTime.Hour >= 12 && dateTime.Minute > 0) ? dateTime.Day + 1 : dateTime.Day;
            DateTime lunchTime = new DateTime(dateTime.Year, dateTime.Month, day, 12, 0, 0);

            Console.WriteLine("Next lunch is in {0} minutes", lunchTime.Subtract(dateTime).TotalMinutes);
        }

        public static void NumberOfCurrentDay(DateTime dateTime)
        {
            Console.WriteLine("Today is the day number {0} in this week", (int) dateTime.DayOfWeek + 1);
        }
    }
}