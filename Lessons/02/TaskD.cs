using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        public static void Run()         {
            IEnumerable<int> ids = Enumerable.Range(1, 15);

            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.SetMinThreads(10, 10);

            Stopwatch stopwatch = new Stopwatch();
            Thread.Sleep(1000);

            foreach (int id in ids) {
                stopwatch.Start();
                ThreadPool.QueueUserWorkItem(x => {
                    Console.WriteLine("Let's do the job.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Aaaaaand it's done.");
                });
                stopwatch.Stop();

                Console.WriteLine("Slave {0} was created and get it's job done in {1} ms", id, stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
            }
        }
    }
}