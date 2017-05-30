using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
            var numbers = Enumerable.Range(1, 1000).ToList();
            try
            {
                Parallel.ForEach(numbers, number => Console.WriteLine(number));
                Parallel.ForEach(numbers, number => numbers.Remove(number));
            }
            catch (AggregateException exception)
            {
                Console.WriteLine(exception.Message);
                foreach (var e in exception.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Exceptions thrown: " + exception.InnerExceptions.Count);
            }

            int concurrentNumber = 0;
            var concurrentNumbers = new ConcurrentBag<int>(Enumerable.Range(1, 1000));

            Parallel.ForEach(concurrentNumbers, number => Console.WriteLine(number));
            Parallel.ForEach(concurrentNumbers, number => concurrentNumbers.TryTake(out concurrentNumber));
        }
    }
}