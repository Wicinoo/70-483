using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Threading.Thread;

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
            ThreadPool.SetMaxThreads(10,10);

            Parallel.For(0, 15, Method);

        }

        private static void Method(int number)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var task = new Task((() => Sleep(1000)));
            task.Start();
            stopwatch.Stop();

            Console.WriteLine($"{number} took {stopwatch.ElapsedTicks}");
        }
    }
}