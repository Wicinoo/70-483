using System;
using Rhino.Mocks.Constraints;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };


            try
            {
                Parallel.ForEach(numbers, x => numbers.RemoveAt(0));
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.Flatten().InnerExceptions)
                {
                    Console.WriteLine("Unsafe collection accesed. Exception: {0}",ex.Message);
                } 
            }
            

            ConcurrentBag<int> nums = new ConcurrentBag<int> {1,2,3,4,5,6};

            int removed;
            Parallel.ForEach(nums, x => nums.TryTake(out removed));

            Console.WriteLine(nums.Count);
        }
    }
}