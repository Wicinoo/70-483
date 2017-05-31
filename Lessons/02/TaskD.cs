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
        private static Stopwatch _sw = new Stopwatch();

        public static void Run()
        {
            Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId}");

            int workerThreads;
            int completionPortThreads;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            ThreadPool.SetMaxThreads(10, completionPortThreads);

            _sw.Start();

            for (int i = 1; i <= 15; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ThreadPool.QueueUserWorkItem(ThreadPoolMethod, new Tuple<Stopwatch, int>(sw, i));
            }

            Console.ReadLine();
        }

        private static void ThreadPoolMethod(object state)
        {
            Tuple<Stopwatch, int> input = (Tuple<Stopwatch, int>)state;
            input.Item1.Stop();
            Console.WriteLine($"i: {input.Item2}, ThreadId: {Thread.CurrentThread.ManagedThreadId}, Elapsed: {input.Item1.ElapsedMilliseconds}");
            Thread.Sleep(10000);
        }
    }
}