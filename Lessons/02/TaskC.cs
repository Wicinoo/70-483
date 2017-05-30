using System.Collections.Concurrent;
using System.Collections.Generic;
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
            var nonSafeList = new List<int> { 1, 45, 53, 4, 47, 45, 2, 8, 9 };

            var safeList = new ConcurrentBag<int> { 1, 45, 53, 4, 47, 45, 2, 8, 9 };


            //foreach (var item in nonSafeList)
            //{
            //    nonSafeList.Remove(item);
            //}

            System.Console.WriteLine($"Safe list count before ForEach: {safeList.Count}");

            Parallel.ForEach(safeList, x =>
            {
                safeList.TryTake(out x);
            });

            System.Console.WriteLine($"Safe list count after ForEeach: {safeList.Count}");
        }
    }
}