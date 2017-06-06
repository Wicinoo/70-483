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
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);

            Stopwatch.Start();

            for (var i = 0; i < 15; i++)
            {
                var startOfCreation = Stopwatch.ElapsedMilliseconds;
                Task.Run(() => { TaskThatTakes1000MsAndPrintsTimeItTookToAllocate(startOfCreation); });
            }
        }

        public static void TaskThatTakes1000MsAndPrintsTimeItTookToAllocate(long startOfCreation)
        {
            Console.WriteLine($"Task waited for execution {Stopwatch.ElapsedMilliseconds - startOfCreation} milliseconds");

            Thread.Sleep(1000);
        }
    }
}