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
            ThreadPool.SetMaxThreads(10,10);

            Stopwatch watch = new Stopwatch();
            ;
            for (int i = 0; i < 15; i++)
            {
                watch.Start();
                ThreadPool.QueueUserWorkItem(x => { Thread.Sleep(1000); });
                watch.Stop();
                Console.WriteLine("Elapsed: {0}",watch.ElapsedMilliseconds);
                watch.Restart();
            }
        }
    }
}