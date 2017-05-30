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
        private static Stopwatch stopwatch = new Stopwatch();
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);
            stopwatch.Start();
            for (int i = 0; i < 15; i++)
            {
                var start = stopwatch.ElapsedMilliseconds;
                Task.Run(() => { WriteTimeFromRequestingTask(start); });

            }
        }

        public static void WriteTimeFromRequestingTask(long requestedAtInMilliseconds)
        {
            var deleayFromStart = stopwatch.ElapsedMilliseconds - requestedAtInMilliseconds;
            Console.WriteLine($"Task waited for execution {deleayFromStart} milliseconds");
            Thread.Sleep(1000);
        }
    }
}