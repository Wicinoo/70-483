using System;
using System.Collections.Generic;

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

            var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek));

            foreach (DayOfWeek dayOfWeek in allDaysOfWeek)
            {
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
            new DayMessageRule(day => day > DateTime.Now.DayOfWeek, day => $"{day} is coming.")
            // #1 add a rule for "Day is coming."
        };


        // #2 add an indexer that returns a message for a DayOfWeek value
        public string this[DayOfWeek day]
        {
            get
            {
                foreach (var dayMessageRule in this.dayMessageRules)
                {
                    if (dayMessageRule.Predicate(day))
                    {
                        return dayMessageRule.Message(day);
                    }
                }
                return "No rule found";
            }
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