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

            for (var i = 0; i < 20; i++)
            {
                stopwatch.Start();
                var task = Task.Run(() =>
                {
                    Console.WriteLine("Task running...");
                    Thread.Sleep(2000);
                });

                stopwatch.Stop();

                Console.WriteLine($"Time elapsed ms: {stopwatch.ElapsedMilliseconds}");
                stopwatch.Reset();
            }
            
        }
    }
}