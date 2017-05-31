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

            var s = new Stopwatch();

            var tasks = new Task[15];

            s.Start();

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Console.WriteLine($"Task Created at {s.Elapsed}");

                    Thread.Sleep(1000);
                });
            }

            Console.WriteLine($"Tasks Started at {s.Elapsed}");

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks);

            Console.WriteLine($"Tasks Finished at {s.Elapsed}");

            s.Stop();
        }
    }
}