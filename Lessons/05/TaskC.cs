using System;
using System.Collections.Generic;
using System.Linq;
namespace Lessons._05
{
    /// <summary>
    /// Class week holds rules for messages about a day in a week.
    /// Implement missing #1 to #4.
    /// </summary>
    public class TaskC {
        public static void Run() {
            Week week = new Week();

            var allDaysOfWeek = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>();

            foreach (DayOfWeek dayOfWeek in allDaysOfWeek){
                Console.WriteLine(week[dayOfWeek]);
            }
        }
    }

    class Week {
        private readonly IEnumerable<DayMessageRule> dayMessageRules = new List<DayMessageRule> {
            new DayMessageRule(day => day < DateTime.Now.DayOfWeek, day => $"{day} is in the past."),
            new DayMessageRule(day => day == DateTime.Now.DayOfWeek, day => $"{day} is now."),
			new DayMessageRule(day => day > DateTime.Now.DayOfWeek, winter => $"{winter} is in the future."),
        };

		public string this[DayOfWeek dayOfWeek] => dayMessageRules.First(x => x.Predicate(dayOfWeek)).Message(dayOfWeek);

		struct DayMessageRule {
            public Predicate<DayOfWeek> Predicate { get; }
            public Func<DayOfWeek, string> Message { get; }

            public DayMessageRule(Predicate<DayOfWeek> predicate, Func<DayOfWeek, string> message) {
                Predicate = predicate;
                Message = message;
            }
        }
    }
}