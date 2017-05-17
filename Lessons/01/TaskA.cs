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

    delegate void PrintDateTimeFunnyInfo(DateTime datetime);

    public class TaskA
    {
        public static void Run()
        {
            DateTime now = DateTime.Now;
            PrintDateTimeFunnyInfo FirstDelegateInstance  = M1;
            FirstDelegateInstance (now);

            PrintDateTimeFunnyInfo SecondDelegateInstance = M1;
            SecondDelegateInstance += M2;
            SecondDelegateInstance(now);

            PrintDateTimeFunnyInfo ThirdDelegateInstance = M1;
            ThirdDelegateInstance += M2;
            ThirdDelegateInstance -= M1;
            ThirdDelegateInstance(now);
        }

        private static void M1(DateTime datetime)
        {
            TimeSpan theTimeSpan = TimeSpan.FromHours(12) - datetime.TimeOfDay;
            double MinutesToLunch = theTimeSpan.TotalMinutes;

            if (MinutesToLunch < 0)
            {
                MinutesToLunch = 24 * 60 + MinutesToLunch;
            }

            Console.WriteLine($"Next lunch is in {Math.Round(MinutesToLunch, 0)} minutes");
        }

        private static void M2(DateTime datetime)
        {
            // Create a method (M2) with the same signature like the delegate that prints the number of current day of week.
            // E.g. For Monday it prints "today is the day number 2 in this week".
            int dayNumber = (int)DateTime.Now.DayOfWeek + 1;
            Console.WriteLine($"today is the day number {dayNumber} in this week");
        }
    }
}