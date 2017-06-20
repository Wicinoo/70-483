using System;
using System.Diagnostics;
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
            ThreadPool.SetMaxThreads(10, 10);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 15; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    item => Task.Run(() => {
                        Console.WriteLine($"Task {item}: {stopwatch.ElapsedMilliseconds} ms");
                        Thread.Sleep(1000);
                    }), i
                );
            }
        }
    }
}