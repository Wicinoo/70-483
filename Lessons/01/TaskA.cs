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
    /// 

    public delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

    public class TaskA
    {
        public static void Run()
        {
            DateTime now = DateTime.Now;

            PrintDateTimeFunnyInfo funnyInfoDelegate = M1;
            Console.WriteLine("M1");
            funnyInfoDelegate(now);

            funnyInfoDelegate += M2;
            Console.WriteLine("M1+M2");
            funnyInfoDelegate(now);

            funnyInfoDelegate -= M1;
            Console.WriteLine("M1+M2-M1");
            funnyInfoDelegate(now);
        }

        public static void M1(DateTime dt)
        {
            if (dt.TimeOfDay.TotalHours <= 12)
            {
                Console.WriteLine(string.Format("Next lunch is in {0} minutes.", (new TimeSpan(12, 0, 0) - dt.TimeOfDay).Minutes));
            }
        }

        public static void M2(DateTime dt)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("cs-cz");
            Console.WriteLine($"Today is the day number {(int)dt.DayOfWeek} of the week");
        }
    }

}