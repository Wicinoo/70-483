using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhino.Mocks.Constraints;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {

        private static readonly List<int> unsafeList = Enumerable.Range(0, 100).ToList();

        private static readonly ConcurrentBag<int> safeBag = new ConcurrentBag<int>(Enumerable.Range(0, 100));  

        public static void Run()
        {
            try
            {
                Parallel.ForEach(unsafeList, x => { unsafeList.RemoveAt(unsafeList.Count - 1); });
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Unsafe AggregateException thrown : " + string.Join(",", e.InnerExceptions.ToList().Select(x => x.Message)));
            }

            try
            {
                Parallel.ForEach(safeBag, x =>
                {
                    int result;
                    safeBag.TryTake(out result);
                });
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Safe AggregateException thrown : " + string.Join(",", e.InnerExceptions.ToList().Select(x => x.Message)));
            }
        }
    }
}