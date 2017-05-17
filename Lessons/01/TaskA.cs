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
            //1
            PrintDateTimeFunnyInfo M1 = m1;
            M1(DateTime.Now);

            PrintDateTimeFunnyInfo M2 = m2;
            /*M2(DateTime.Now);*/

            //2
            PrintDateTimeFunnyInfo M3 = m1;
            M3 += M2;
            M3(DateTime.Now);


            //Console.WriteLine(M4.GetInvocationList().GetLength(0));
            //3
            PrintDateTimeFunnyInfo M4 = m1;
            M4 += M2;
            M4 -= M1;
            M4(DateTime.Now);

           // Console.WriteLine(M4.GetInvocationList().GetLength(0)); 
        }

        public static void m1(DateTime dateTime)
        {
            var lunchTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 12, 0, 0);
            var message = "Next lunch is in {0} minutes";
            if (dateTime <= lunchTime)
            {
                PrintOutputToConsole(message, lunchTime.Subtract(dateTime).TotalMinutes);
            }
            else
            {
                var nextLunch = lunchTime.AddDays(1);
                PrintOutputToConsole(message, nextLunch.Subtract(dateTime).TotalMinutes);
            }
        }

        public static void m2(DateTime dateTime)
        {
            var message = "today is the day number {0} in this week";
            var dayOfWeek = Convert.ToDouble(dateTime.DayOfWeek)+1;

            PrintOutputToConsole(message,dayOfWeek);
        }


        private static void PrintOutputToConsole(string message, double value)
        {
            Console.WriteLine(String.Format(message, value));
        }
    }

}