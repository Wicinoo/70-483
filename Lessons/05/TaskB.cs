using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

    public static class ExtensionMethods
    {
        public static string GetTodayOpening(this OpeningDays e)
        {
            OpeningDays today = OpeningDays(DateTime.Now.DayOfWeek);

            if ((today & e) != 0)
            {
                return State.Opened.ToString();
            }

            return State.Closed.ToString();
        }

        private static OpeningDays OpeningDays(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday: return _05.OpeningDays.Monday;
                case DayOfWeek.Tuesday: return _05.OpeningDays.Tuesday;
                case DayOfWeek.Wednesday: return _05.OpeningDays.Wednesday;
                case DayOfWeek.Thursday: return _05.OpeningDays.Thursday;
                case DayOfWeek.Friday: return _05.OpeningDays.Friday;
                case DayOfWeek.Saturday: return _05.OpeningDays.Saturday;
                case DayOfWeek.Sunday: return _05.OpeningDays.Sunday;
            }

            return _05.OpeningDays.None;
        }
    }


    [Flags]
    public enum OpeningDays : byte
    {        
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    enum State
    {
        Unknown,
        Opened,
        Closed
    }
}