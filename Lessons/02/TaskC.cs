using System;

namespace Lessons._02
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        public static void Run()
        {
            Dictionary<int, Guid> dict = new Dictionary<int, Guid>();
            try
            {
                Parallel.ForEach(Enumerable.Range(0, 10000), item =>
                {
                    dict.Add(item, Guid.NewGuid());
                    Guid value;
                    dict.TryGetValue(item, out value);
                    Console.WriteLine($"Key: {item}, Value: {value}");
                });
                Console.ReadKey();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Unsafe dictionary fails with exception: {ex.InnerExceptions.First().Message}");
                Console.ReadKey();
            }

            ConcurrentDictionary<int, Guid> saveDict = new ConcurrentDictionary<int, Guid>();
            Parallel.ForEach(Enumerable.Range(0, 10000), item =>
            {
                saveDict.TryAdd(item, Guid.NewGuid());
                Guid value;
                saveDict.TryGetValue(item, out value);
                Console.WriteLine($"Key: {item}, Value: {value}");
            });
        }
    }
}