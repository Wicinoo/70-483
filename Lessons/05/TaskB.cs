using System;
using System.Collections;

namespace Lessons._05
{
    /// <summary>
    /// * Declare an flagged enum type OpeningDays with all days in week. 
    /// * Declare an extension method GetTodayOpening() for the type OpeningDays.
    /// It returns Opened if a value contains today, otherwise Closed.
    /// * Opened and Closed are values of an another custom enum type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {

        Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening()}");
        Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening()}");
        Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening()}");
        Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening()}");
        Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening()}");
    }
}

    public enum OpeningDays
    {
        None = 1,
        Sunday = 2,
        Monday = 4,
        Tuesday = 8,
        Wednesday = 16,
        Thursday =32,
        Friday = 64,
        Saturday = 128
    }

    public static class Extensions
    {
        public static string GetTodayOpening(this OpeningDays e)
        {
            bool isOpened = false;
            bool isClosed = false;

            int deep = 0;
            while (e>0)
            {
                var current = ((int)e % 2 ) * (int)Math.Pow(2,deep);
                switch ((OpeningDays)current)
                {
                    case OpeningDays.None:
                        isClosed = true;
                        break;
                    case OpeningDays.Sunday:
                        isClosed = true;
                        break;
                    case OpeningDays.Monday:
                        isOpened = true;
                        break;
                    case OpeningDays.Wednesday:
                        isOpened = true;
                        break;
                    case OpeningDays.Tuesday:
                        isOpened = true;
                        break;
                    case OpeningDays.Saturday:
                        isClosed = true;
                        break;
                    case OpeningDays.Thursday:
                        isClosed = true;
                        break;
                }
                e = (OpeningDays)((int)e / 2);
                deep++;
            }
            string opened = String.Empty;
            if (isClosed & !isOpened) opened = "is closed";
            if (!isClosed & isOpened) opened = "is opened";
            if (!isClosed & !isOpened) opened = "Undefined";
            if (isClosed & isOpened) opened = "in some days is opened and in some is closed";

            return opened;
        }
    }

}