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
    public struct TaskC
    {
        
        public static void Run()
        {
            Dictionary<int, int> dict = new Dictionary<int, int> { { 1, 1 }, { 2, 2 } };
            
            IEnumerable<int> attempts = Enumerable.Range(1, 20);

            //not failing but I have no clue what would fail so lets leave it like this
            try
            {
                Parallel.ForEach(attempts, x =>
                {
                    dict.Remove(1);
                });
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(String.Format("Draw me like one of your aggregate exceptions: {0}", ae.Message));
            }


            ConcurrentDictionary<int, int> safeDict = new ConcurrentDictionary<int, int>();

            safeDict.TryAdd(1,1);
            try
            {
                Parallel.ForEach(attempts, x =>
                {
                    int val;
                    safeDict.TryRemove(1, out val);
                });
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(String.Format("You were supposed to be the chosen one! {0}", ae.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Snake? Snake!? Snaaake! {0}", e.Message));
            }
        }
    }
}