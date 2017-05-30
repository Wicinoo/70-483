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
            Stopwatch stopwatch = new Stopwatch();
            ThreadPool.SetMaxThreads(10, 10);

            for (int i = 0; i < 15; i++)
            {
                if (stopwatch.IsRunning)
                {
                    stopwatch.Restart();
                }
                else
                {
                    stopwatch.Stop();
                }

                ThreadPool.QueueUserWorkItem(x =>
                {
                    Console.WriteLine(i);
                    Thread.Sleep(2000);
                });

                stopwatch.Stop();
                Console.WriteLine($"Creating thread {i} took {stopwatch.ElapsedMilliseconds}.");
            }
        }
    }
}