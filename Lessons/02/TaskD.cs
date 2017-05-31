using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            ThreadPool.SetMaxThreads(0, 10);

            Parallel.For(0, 15, i =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var time = new TimeSpan();
                var task = Task.Run(() =>
                {
                    time = stopWatch.Elapsed;
                    Thread.Sleep(1000);
                });

                Console.WriteLine("Task {0} creation time: {1}", i.ToString(), stopWatch.Elapsed.TotalMilliseconds);
            });
        } 
    }
}