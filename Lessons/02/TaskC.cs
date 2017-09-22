using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            var numbers = Enumerable.Range(0, 100).ToList();
            var specialNumbers = Enumerable.Range(0, 10).ToList();

            try
            {
                Parallel.ForEach(numbers, i =>
                {
                    if (i % 3 == 0)
                        specialNumbers.Add(i);
                } );
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"There were {ex.InnerExceptions.Count} exceptions.");
            }

            specialNumbers.ForEach(Console.WriteLine);
        }
    }
}