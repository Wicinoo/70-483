using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

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
            try
            {
                List<int> unsafeCollection = new List<int>();

                Parallel.ForEach(Enumerable.Range(0, 999), x =>
                {
                    unsafeCollection.Add(x);
                    Parallel.ForEach(Enumerable.Range(0, 999), y => { unsafeCollection.Add(y); });
                    Console.WriteLine(unsafeCollection.Count);
                });
                Console.WriteLine("unsafe OK");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write("unsafe failed");
            }

            try
            {
                BlockingCollection<int> safeCollection = new BlockingCollection<int>();
                Parallel.ForEach(Enumerable.Range(0, 999), x =>
                {
                    safeCollection.Add(x);
                    Parallel.ForEach(Enumerable.Range(0, 999), y => { safeCollection.Add(y); });
                    Console.WriteLine(safeCollection.Count);
                });
                Console.WriteLine("safe OK");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write("safe failed");
            }
        }
    }
}
