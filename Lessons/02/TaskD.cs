using System;
using System.Diagnostics;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < 15; i++)
            {
                stopwatch.Start();
                ThreadPool.QueueUserWorkItem(MineBitcoin);
                stopwatch.Stop();

                int availableThreads; int availableIoThreads;
                ThreadPool.GetAvailableThreads(out availableThreads, out availableIoThreads);

                Console.WriteLine($"Thread number {i} took: {stopwatch.ElapsedMilliseconds}ms to queue. Threads available: {availableThreads}");
                stopwatch.Reset();
            }
        }

        private static void MineBitcoin(object state)
        {
            Console.WriteLine("---Started Mining!");
            Thread.Sleep(3000);
            Console.WriteLine("---Bitcoin mined!");
        }
    }
}