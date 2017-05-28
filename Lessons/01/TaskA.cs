using System;
using System.Linq;

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
        private static readonly TimeSpan lunch = new TimeSpan(12, 0, 0);

        public delegate void PrintDateTimeFunnyInfo(DateTime input);

        public static void Run()
        {
            Console.WriteLine("1.:");
            PrintDateTimeFunnyInfo printInfo1 = MinutesToLunch;
            printInfo1(DateTime.Now);

            Console.WriteLine("2.:");
            PrintDateTimeFunnyInfo printInfo2 = MinutesToLunch;
            printInfo2 += DayNumberOfTheWeek;
            printInfo2(DateTime.Now);

            Console.WriteLine("3.:");
            PrintDateTimeFunnyInfo printInfo3 = MinutesToLunch;
            printInfo3 += DayNumberOfTheWeek;
            printInfo3 -= MinutesToLunch;
            printInfo3(DateTime.Now);
        }

        private static void MinutesToLunch(DateTime input)
        {
            double result = 0;
            if (lunch >= input.TimeOfDay)
            {
                result = (lunch - input.TimeOfDay).TotalMinutes;
            }
            else if (lunch < input.TimeOfDay)
            {
                result = (24 * 60 - input.TimeOfDay.TotalMinutes) + 12 * 60;
            }

            Console.WriteLine($"Next lunch is in {result.ToString("N0")} minutes.");
        }

        private static void DayNumberOfTheWeek(DateTime input)
        {
            var number =
                Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .ToList()
                .Where(day => day == input.DayOfWeek)
                .Select(day => Convert.ToInt32(day))
                .FirstOrDefault();

            Console.WriteLine($"Today is the day number {number} in this week.");
        }
    }
}