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
            var watch = new Stopwatch();
            ThreadPool.SetMaxThreads(10, 10);

            for (var i = 0; i < 10; i++)
            {
                watch.Start();
                ThreadPool.QueueUserWorkItem(WorkItemCallBack, i);
                watch.Stop();
                Console.WriteLine("Elapsed for task no {0} is {1}", i, watch.Elapsed);
                watch.Reset();
            }
        }

        public static void WorkItemCallBack(Object threadContext)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Im sleeping thread no {0}", threadContext);
        }
    }
}