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
            UnsafeExample();
            SafeExample();

            Console.WriteLine("Processing done");
        }

        private static void UnsafeExample()
        {
            var queue = new Queue<int>();

            try
            {
                Parallel.ForEach(Enumerable.Range(0, 1000), num =>
                {
                    queue.Enqueue(num);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void SafeExample()
        {
            var queue = new ConcurrentQueue<int>();

            Parallel.ForEach(Enumerable.Range(0, 1000), num =>
            {
                queue.Enqueue(num);
            });
        }
    }
}