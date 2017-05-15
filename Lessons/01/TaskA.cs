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
            PrintDateTimeFunnyInfo firstExample = M1;
            firstExample(DateTime.Now);

            PrintDateTimeFunnyInfo secondExample = M1;
            secondExample += M2;
            secondExample(DateTime.Now);

            PrintDateTimeFunnyInfo thirdExample = M1;
            thirdExample += M2;
            thirdExample -= M1;
            thirdExample(DateTime.Now);
        }

        public static void M1(DateTime dateTime)
        {
            var noon = DateTime.Today.AddHours(12);

            var nextNoon = DateTime.Now > noon ? noon.AddDays(1) : noon;
            var minutesToLunch = (int) (nextNoon - DateTime.Now).TotalMinutes;

            Console.WriteLine($"Next lunch is in {minutesToLunch} minutes");
        }

        public static void M2(DateTime dateTimeime)
        {
            Console.WriteLine($"Today is the day number {(int) DateTime.Today.DayOfWeek} in this week");
        }
    }
}