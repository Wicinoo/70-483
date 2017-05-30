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
            ThreadPool.SetMaxThreads(15,15);
            var st = new Stopwatch();


            var cts = new CancellationTokenSource();
            TaskFactory taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);


            st.Start();
            
            for(int i = 0; i < 15; i++)
            {
                taskFactory.StartNew(
                    (num) =>
                    {
                        Console.WriteLine("Task {0} starting at {1}", (int)num, st.Elapsed);
                        Thread.Sleep(1500);
                    }, i);
            }

            Thread.Sleep(3000);
            Console.WriteLine("TaskD finished");
        }
    }
}