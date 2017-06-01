using System;
using System.Diagnostics;
using System.Threading;

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
            var clockDevice = new Stopwatch();


            for (int x = 1; x < 16; x++)
            {
                clockDevice.Restart();
                ThreadPool.QueueUserWorkItem(z =>
                {
                    Thread.Sleep(new Random().Next(1000, 2000));
                }, x);
                clockDevice.Stop();

                Console.WriteLine("Created task no. " + x.ToString() + " in " + clockDevice.Elapsed.TotalMilliseconds + "miliseconds");
            }
        }
    }
}