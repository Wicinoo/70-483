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

            var allDaysOfWeek = GetDaysOfWeek(); // #3 get all DayOfWeek values 

            foreach (var dayOfWeek in allDaysOfWeek)
            {
                Console.WriteLine(week[dayOfWeek]);
            }
        }

        private static DayOfWeek[] GetDaysOfWeek()
        {
            var arrayLenght = Enum.GetNames(typeof(DayOfWeek)).Length;

            var array = new DayOfWeek[arrayLenght];

            for (int i = 0; i < arrayLenght; i++)
            {
                array[i] = (DayOfWeek)i;
            }

            return array;
        }
    }

    class Week
    {
        private readonly IEnumerable<DayMessageRule> dayMessageRules = new List<DayMessageRule>
        {
            new DayMessageRule(day => day < DateTime.Now.DayOfWeek, day => $"{day} is gone."),
            new DayMessageRule(day => day == DateTime.Now.DayOfWeek, day => $"{day} is today."),
            new DayMessageRule(day => day > DateTime.Now.DayOfWeek, day => $"{day} is coming."),

            // #1 add a rule for "Day is coming."
        };

        // #2 add an indexer that returns a message for a DayOfWeek value

        public string this[DayOfWeek day]
        {
            get
            {
                foreach (var rule in dayMessageRules)
                {
                    if (rule.Predicate(day))
                    {
                        return rule.Message(day);
                    }
                }

                return string.Empty;
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