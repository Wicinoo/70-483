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
            ForEach();

            ParallelForEach();
        }

        private static void ForEach()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            var bag = new ConcurrentBag<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

            Console.WriteLine($"Initial: list.Count(): {list.Count}, bag.Count(): {bag.Count}");

            try
            {
                foreach (var i in list)
                {
                    list.Remove(i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"forech on list with exception: {e.Message}");
            }

            //compile error
            //foreach (var i in bag)
            //{
            //    bag.TryTake(out i);
            //}

            Console.WriteLine($"Result list.Count(): {list.Count}, bag.Count(): {bag.Count}");
        }

        private static void ParallelForEach()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            var bag = new ConcurrentBag<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

            Console.WriteLine($"Initial: list.Count(): {list.Count}, bag.Count(): {bag.Count}");


            try
            {
                Parallel.ForEach(list, i => list.Remove(i));
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"Prallel.ForEach on list with exception: {e.InnerExceptions.First().Message}");
            }

            Parallel.ForEach(bag, i => bag.TryTake(out i));

            Console.WriteLine($"Result list.Count(): {list.Count}, bag.Count(): {bag.Count}");
        }
    }
}