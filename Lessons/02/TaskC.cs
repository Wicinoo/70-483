using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public class TaskC {
        public static void Run() {
            var collection = new List<int>(Enumerable.Range(0, 333));

            try {
                Parallel.ForEach(collection, x => {
                    if (x % 2 == 0) {
                        collection.Add(x);
                    }
                });
            } catch (AggregateException) {
                Console.WriteLine("Gotcha!");
            }

            var safeCollection = new BlockingCollection<int>();
            safeCollection.TryAdd(1);
            safeCollection.TryAdd(2);

            Parallel.ForEach(safeCollection, x => {
                if (x % 2 == 0) {
                    safeCollection.TryAdd(x);
                }
            });

            foreach (var item in safeCollection) {
                Console.WriteLine(item);
            }
        }
    }
}