using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        public static void Run()
        {
            var days = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>();

            try
            {
                var weekendDays = days
                    .AsParallel()
                    .Where(day => IsWeekend(day));

                weekendDays.ForAll(day => Console.WriteLine(day));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Number of inner exceptions: {ex.InnerExceptions.Count}");
            }

            Concurrent();
        }

        private static bool IsWeekend(DayOfWeek day)
        {
            if (day == DayOfWeek.Friday) throw new ArgumentException("Almost there.");

            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        private static void Concurrent()
        {
            var daysUnsafe = Enum.GetValues(typeof(DayOfWeek))
                   .Cast<DayOfWeek>()
                   .Where(day => day != DayOfWeek.Friday);

            ConcurrentBag<DayOfWeek> days = new ConcurrentBag<DayOfWeek>(daysUnsafe);

            try
            {
                var weekendDays = days
                    .AsParallel()
                    .Where(day => IsWeekend(day));

                weekendDays.ForAll(day => Console.WriteLine(day));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Number of inner exceptions: {ex.InnerExceptions.Count}");
            }
        }
    }
}