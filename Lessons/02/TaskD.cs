using System;

namespace Lessons._02
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.SetMinThreads(10, 10);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= 15; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    state => Task.Run(
                        () =>
                            {
                                Console.WriteLine($"{sw.Elapsed}");
                                Thread.Sleep(1000);
                            }));
            }
        }
    }
}