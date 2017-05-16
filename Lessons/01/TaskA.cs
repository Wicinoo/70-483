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
        public delegate void PrintDateTimeFunnyInfo(DateTime date);

        public static void PrintMinutesToLunch(DateTime date)
        {
            var todaysTime = DateTime.Now;
            var noon = new TimeSpan(12, 0, 0);

            var isAfternoon = todaysTime.TimeOfDay > noon;
            var tomorrowsTime = todaysTime.AddDays(1);

            var lunchTime = isAfternoon ? tomorrowsTime.Date + noon : todaysTime + noon;

            var minutesToLunch = (lunchTime - todaysTime).TotalMinutes;

            Console.WriteLine($"Next lunch is in { minutesToLunch } minutes");
        }

        public static void PrintDayOfWeek(DateTime date)
        {
            var dayOfTheWeek = DateTime.Now.DayOfWeek;            
            int numberOfWeekDay = Convert.ToInt32(dayOfTheWeek);

            Console.WriteLine($"Today is the number {numberOfWeekDay} of this week");
        }

        public static void Run()
        {
            PrintDateTimeFunnyInfo printMinutesToLunch = PrintMinutesToLunch;
            printMinutesToLunch(DateTime.Now);

            PrintDateTimeFunnyInfo printMinutesToLunchAndDayOfWeek = PrintMinutesToLunch;
            printMinutesToLunchAndDayOfWeek += PrintDayOfWeek;
            printMinutesToLunchAndDayOfWeek(DateTime.Now);

            PrintDateTimeFunnyInfo printDayOfWeekMinusMinutesToLunch = PrintMinutesToLunch;
            printDayOfWeekMinusMinutesToLunch += PrintDayOfWeek;
            printDayOfWeekMinusMinutesToLunch -= PrintMinutesToLunch;
            printDayOfWeekMinusMinutesToLunch(DateTime.Now);
        }
    }
}