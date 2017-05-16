using System;
using FluentAssertions.Numeric;

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
            var number1 = new PrintDateTimeFunnyInfo(M1);
            number1(DateTime.Now);

            var number2 = new PrintDateTimeFunnyInfo(M1);
            number2 += M2;
            number2(DateTime.Now);

            var number3 = new PrintDateTimeFunnyInfo(M1);
            number3 += M2;
            number3 -= M1;
            number3(DateTime.Now);
         }

        private static void M1(DateTime dateTime)
        {
            var nextLunch = dateTime.Hour < 12
                ? new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 12, 0, 0)
                : new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 12, 0, 0).AddDays(1);

            var minutesToLaunch = Math.Round((nextLunch - dateTime).TotalMinutes);
            Console.WriteLine($"Next lunch is in {minutesToLaunch} miutes");
        }

        private static void M2(DateTime dateTime)
        {
            Console.WriteLine($"Today is the day number {((int)dateTime.DayOfWeek)+1} in this week");
        }
    }
}