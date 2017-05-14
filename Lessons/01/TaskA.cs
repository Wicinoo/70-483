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
        public delegate void PrintDateTimeFunnyInfo(DateTime input);

        public static void Run()
        {
            Console.WriteLine("Delegate 1: ");
            PrintDateTimeFunnyInfo del1 = MinutesToNextLunch;
            del1(DateTime.Now);

            Console.WriteLine("\r\nDelegate 2:");
            PrintDateTimeFunnyInfo del2 = MinutesToNextLunch;
            del2 += DayOfWeek;
            del2(DateTime.Now);

            Console.WriteLine("\r\nDelegate 3:");
            PrintDateTimeFunnyInfo del3 = MinutesToNextLunch;
            del3 += DayOfWeek;
            del3 -= MinutesToNextLunch;
            del3(DateTime.Now);
        }

        public static void MinutesToNextLunch(DateTime dt)
        {
            double minutes;
            if (dt.Hour < 12)
            {
                minutes = (DateTime.Now.Date.AddHours(12) - dt).TotalMinutes;
            }
            else
            {
                minutes = (DateTime.Now.Date.AddHours(36) - dt).TotalMinutes;
            }
            int minutesToNextLunch = (int)Math.Round(minutes, MidpointRounding.AwayFromZero);
            Console.WriteLine($"Next lunch is in {minutesToNextLunch} minutes");
        }

        public static void DayOfWeek(DateTime dt)
        {
            Console.WriteLine($"Today is the day number {(int)dt.DayOfWeek + 1} of this week");
        }
    }
}