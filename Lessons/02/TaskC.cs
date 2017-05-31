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
            var numbers = Enumerable.Range(0, 1000000);

            try
            {
                var result = ConcurrentUnsafe(numbers);
                Console.WriteLine($"Concurrent unsafe, count: {result.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Concurrent unsafe exception: {ex.ToString()}");
            }

            var result2 = ConcurrentSafe(numbers);
            Console.WriteLine($"Concurrent safe, count: {result2.Count}");

        }

        public static List<int> ConcurrentUnsafe(IEnumerable<int> numbers)
        {
            //method will either fail because List<T>.Add() is not thread safe or the item count will not be correct 
            List<int> result = new List<int>();
            
            Parallel.ForEach(numbers, (n) =>
            {
                result.Add(n);
            });

            if (result.Count != numbers.Count())
            {
                throw new Exception($"Count not adding up, {result.Count} != {numbers.Count()}");
            }

            return result;
        }

        public static BlockingCollection<int> ConcurrentSafe(IEnumerable<int> numbers)
        {
            BlockingCollection<int> result = new BlockingCollection<int>();

            Parallel.ForEach(numbers, (n) =>
            {
                result.Add(n);
            });

            return result;
        }
    }
}