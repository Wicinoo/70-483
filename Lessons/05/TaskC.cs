using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons._05
{
    /// <summary>
    /// Class week holds rules for messages about a day in a week.
    /// Implement missing #1 to #4.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            var week = new Week();

            var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>(); // #3 get all DayOfWeek values 

            foreach (var dayOfWeek in allDaysOfWeek)
            {
                Console.WriteLine(week[dayOfWeek]); // #4 
            }
        }
    }

    class Week
    {
        private readonly IEnumerable<DayMessageRule> dayMessageRules = new List<DayMessageRule>
        {
            new DayMessageRule(day => day < DateTime.Now.DayOfWeek, day => $"{day} is gone."),
            new DayMessageRule(day => day == DateTime.Now.DayOfWeek, day => $"{day} is today."),
            new DayMessageRule(day => day > DateTime.Now.DayOfWeek, day => $"{day} is coming.") // #1 add a rule for "Day is coming."
        };

        // #2 add an indexer that returns a message for a DayOfWeek value
        public string this[DayOfWeek day]
        {
            get { return dayMessageRules.Single(x => x.Predicate(day)).Message(day); }
        }

        struct DayMessageRule
        {
            public Predicate<DayOfWeek> Predicate { get; } // in day, out bool
            public Func<DayOfWeek, string> Message { get; } // in day, out string

            public DayMessageRule(Predicate<DayOfWeek> predicate, Func<DayOfWeek, string> message)
            {
                Predicate = predicate;
                Message = message;
            }
        }
    }
}