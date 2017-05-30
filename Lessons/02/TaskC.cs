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
            var l = new LinkedList<int>(Enumerable.Range(0, 1000));

            try
            {
                Parallel.ForEach(l, x => { if (x % 2 == 0) l.AddLast(x); });
                throw new Exception("expected exception was not thrown.");
            }
            catch (AggregateException)
            {
            }


            var b = new BlockingCollection<int>();
            b.TryAdd(1);
            b.TryAdd(2);

            Parallel.ForEach(b, x => { if (x % 2 == 0) b.TryAdd(x); });
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }
        }
    }
}