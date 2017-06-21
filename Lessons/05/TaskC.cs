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

            //var allDaysOfWeek = new DayOfWeek[7]; // #3 get all DayOfWeek values 
            var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>(); 
            

            foreach (var dayOfWeek in allDaysOfWeek)
            {
                // #4 Console.WriteLine(week[dayOfWeek]);
                Console.WriteLine(week[dayOfWeek]);
            }
        }
    }

    class Week
    {
        private readonly IEnumerable<DayMessageRule> dayMessageRules = new List<DayMessageRule>
        {
            new DayMessageRule(day => day < DateTime.Now.DayOfWeek, day => $"{day} is gone."),
            new DayMessageRule(day => day == DateTime.Now.DayOfWeek, day => $"{day} is today."),
            // #1 add a rule for "Day is coming."
            new DayMessageRule(day => day > DateTime.Today.DayOfWeek, day => $"{day} is coming")
        };

        // #2 add an indexer that returns a message for a DayOfWeek value
        public string this[DayOfWeek key]
        {
            get { return dayMessageRules.First(x => x.Predicate(key)).Message(key); }
        }


        struct DayMessageRule
        {
            public Predicate<DayOfWeek> Predicate { get; }
            public Func<DayOfWeek, string> Message { get; }

            public DayMessageRule(Predicate<DayOfWeek> predicate, Func<DayOfWeek, string> message)
            {
                Predicate = predicate;
                Message = message;
            }
        }
    }
}