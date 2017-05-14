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
        private delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

        public static void Run()
        {
            var m1Only = new PrintDateTimeFunnyInfo(M1);

            m1Only(DateTime.Now);


            var m1AndM2 = new PrintDateTimeFunnyInfo(M1);

            m1AndM2 += M2;

            m1AndM2(DateTime.Now);


            var m1AndM2MinusM1 = new PrintDateTimeFunnyInfo(M1);

            m1AndM2MinusM1 += M2;

            m1AndM2MinusM1 -= M1;

            m1AndM2MinusM1(DateTime.Now);
        }


        private static void M1(DateTime dateTime)
        {
            int minsToNextLunch = GetMinsToNextLunch(dateTime);

            PrintMinsToNextLunch(minsToNextLunch);
        }

        private static int GetMinsToNextLunch(DateTime dateTime)
        {
            var sameDayLunchTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 12, 0, 0);

            var correctedDayLunchTime = sameDayLunchTime >= dateTime ? sameDayLunchTime :
                sameDayLunchTime.AddDays(1);

            var timeToNextLunch = correctedDayLunchTime.Subtract(dateTime);

            var minsToNextLunch = (int)timeToNextLunch.TotalMinutes;

            return minsToNextLunch;
        }

        private static void PrintMinsToNextLunch(int minsToNextLunch)
        {
            var minsEnding = minsToNextLunch == 1 ? "minute" : "minutes";

            Console.WriteLine($"Next lunch is in {minsToNextLunch} {minsEnding}");
        }


        private static void M2(DateTime dateTime)
        {
            Console.WriteLine($"today is the day number {(int)dateTime.DayOfWeek + 1} in this week");
        }
    }
}