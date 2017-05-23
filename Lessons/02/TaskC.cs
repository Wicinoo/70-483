using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
            var numbers = new List<int>() { 1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4};
            var unsafeDictionary = new Dictionary<int, int>()
            {
                { 1,1 }, { 2,2 }, { 3,3 }, { 4,4 }, { 5,5 }

            };

            var safeDictionary = new ConcurrentDictionary<int, int>();
            safeDictionary.TryAdd(1, 1);
            safeDictionary.TryAdd(2, 2);
            safeDictionary.TryAdd(3, 3);
            safeDictionary.TryAdd(4, 4);
            safeDictionary.TryAdd(5, 5);

            //the unsafe dictionary example
            //Parallel.ForEach(numbers, x =>
            //{
            //    Console.WriteLine(unsafeDictionary[x]);
            //    unsafeDictionary.Remove(x);
            //    Thread.Sleep(10);
            //    unsafeDictionary[x] = x;
            //});
            //Console.WriteLine(unsafeDictionary.Count);

            var y = 0;
            Parallel.ForEach(numbers, x =>
            {
                if (safeDictionary.TryGetValue(x, out y))
                {
                    Console.WriteLine(y);
                }
                safeDictionary.TryRemove(x, out y);
                Thread.Sleep(10);
                safeDictionary[x] = x;
            });
        }

        
    }
}