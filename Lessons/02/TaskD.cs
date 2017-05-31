using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        private  static Stopwatch _stopwatch = new Stopwatch();
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.SetMinThreads(10, 10);
            foreach (int taskId in Enumerable.Range(1, 15))
            {
                _stopwatch.Restart();
                ThreadPool.QueueUserWorkItem(x => Thread.Sleep(1000));
                _stopwatch.Stop();
                Console.WriteLine("Task total" + taskId + ":" + _stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
