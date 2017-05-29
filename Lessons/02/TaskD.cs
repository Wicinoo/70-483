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
            var watch = new Stopwatch();
            ThreadPool.SetMaxThreads(10, 10);

            watch.Start();
            Task taskPool = Task.Run(() =>
            {
                TaskFactory factory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None);
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
                factory.StartNew(() => PrintTaskCreationTime(watch));
            });

            taskPool.Wait();
            watch.Stop();
            Console.WriteLine("all tasks completed at " + watch.Elapsed);
        }

        private static void PrintTaskCreationTime(Stopwatch watch)
        {
            Console.WriteLine("Task " + Task.CurrentId + " created at " + watch.Elapsed);
            Thread.Sleep(1000);
            //await Task.Delay(1000);
        }
    }
}