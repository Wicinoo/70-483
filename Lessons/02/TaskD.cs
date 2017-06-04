using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public static class TaskD
    {
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 0);
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 15; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                tasks.Add(Task.Run(() => worker(i)));
                watch.Stop();
                Console.WriteLine("Task {0} creation time {1}", i, watch.ElapsedMilliseconds);
            }
        }

        private static void worker(int i)
        {
            Console.WriteLine("Runing task {0}.", i);
            Thread.Sleep(1000);
        }

    }
}