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
        public delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

        public static void Run()
        {
            PrintDateTimeFunnyInfo minutesToLunch = PrintMinutesToLunch;
            minutesToLunch(DateTime.Now);

            PrintDateTimeFunnyInfo dayOfWeek = PrintDayOfWeek;
            dayOfWeek(DateTime.Now);

            PrintDateTimeFunnyInfo minutesToLunchAndDayOfWeek = PrintMinutesToLunch;
            minutesToLunchAndDayOfWeek += PrintDayOfWeek;
            minutesToLunchAndDayOfWeek(DateTime.Now);

            minutesToLunchAndDayOfWeek -= PrintDayOfWeek;
            minutesToLunchAndDayOfWeek(DateTime.Now);
        }

        public static void PrintMinutesToLunch(DateTime dateTime)
        {
            var nextLunchTime = DateTime.Today.AddDays(1).AddHours(12);
            Console.WriteLine("Next lunch is in {0} minutes", ((nextLunchTime - dateTime).Hours) * 60 + dateTime.Minute);
        }

        public static void PrintDayOfWeek(DateTime dateTime)
        {
            Console.WriteLine("today is the day number {0} in this week", (int)dateTime.DayOfWeek);
        }
    }
}