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

            var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToArray();//new DayOfWeek[0]; // #3 get all DayOfWeek values 

            foreach (var dayOfWeek in allDaysOfWeek)
            {
                /*// #4*/ Console.WriteLine(week[dayOfWeek]);
            }
        }
    }

    class Week
    {
        private readonly IEnumerable<DayMessageRule> dayMessageRules = new List<DayMessageRule>
        {
            new DayMessageRule(day => day < DateTime.Now.DayOfWeek, day => string.Format("{0} is gone.",day)),
            new DayMessageRule(day => day == DateTime.Now.DayOfWeek, day => string.Format("{0} is today.",day)),
            // #1 add a rule for "Day is coming."
            new DayMessageRule(day => day > DateTime.Now.DayOfWeek, day => string.Format("{0} is coming.",day))
        };

        // #2 add an indexer that returns a message for a DayOfWeek value
        public string this[DayOfWeek dayOfWeek] => dayMessageRules.First(rule => rule.Predicate(dayOfWeek)).Message(dayOfWeek);

        struct DayMessageRule
        {
            public Predicate<DayOfWeek> Predicate { get; private set; }
            public Func<DayOfWeek, string> Message { get; private set; }

            public DayMessageRule(Predicate<DayOfWeek> predicate, Func<DayOfWeek, string> message)
            {
                Predicate = predicate;
                Message = message;
            }
        }
    }
}
