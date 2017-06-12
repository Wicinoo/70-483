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

            var tasks = new Task[15];

            Parallel.ForEach(tasks, task => {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                Task.Run(() =>
                {
                });
                stopWatch.Stop();
                TimeSpan elapsed = stopWatch.Elapsed;
                Console.WriteLine(String.Format("{0:00}:{1:0000}", elapsed.Seconds, elapsed.Milliseconds));
            });
        }
    }
}