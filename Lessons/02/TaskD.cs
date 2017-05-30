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
        private const int PoolCapacity = 10;
        private const int PoolAsyncIOThreads = 1000;
        private const int ThreadsToRun = 15;
        private const int ThreadDelay = 1000;

        public static void Run()
        {
            ThreadPool.SetMaxThreads(PoolCapacity, PoolAsyncIOThreads);

            for (int i = 0; i < ThreadsToRun; i++)
            {
                var timer = new Stopwatch();
                var threadId = i + 1;
                timer.Reset();
                timer.Start();

                ThreadPool.QueueUserWorkItem(s => ThreadPoolWorkItem(threadId, timer));
            }
        }

        private static void ThreadPoolWorkItem(int threadId, Stopwatch timer)
        {
            timer.Stop();
            Console.WriteLine("Thread {0} : {1} ms", threadId, timer.ElapsedMilliseconds);
            Thread.Sleep(ThreadDelay);
        }
    }
}