using System;

namespace Lessons._02
{
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
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
            IEnumerable<int> range = Enumerable.Range(0, 50);

            var safe = new ConcurrentBag<int>(range);
            var nonsafe = new List<int>(range);

            Parallel.ForEach(nonsafe,
                x =>
                    { nonsafe[0] += x;
                        Console.WriteLine(nonsafe[0]);
                    });

            Parallel.ForEach(safe,
                x =>
                {
                    Console.WriteLine(x);
                });
        }
    }
}