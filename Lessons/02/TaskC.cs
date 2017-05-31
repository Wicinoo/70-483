using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FluentAssertions.Numeric;

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
            //var unsafeCollection = new Queue<int>(Enumerable.Range(1, 1000));

            //Parallel.ForEach(unsafeCollection, number =>
            //{
            //    unsafeCollection.Dequeue();
            //});

            
            var safeQueue = new ConcurrentQueue<int>(Enumerable.Range(1, 1000));

            int t;
            Parallel.ForEach(safeQueue, number =>
            {
                safeQueue.TryDequeue(out t);
            });

        }
    }
}