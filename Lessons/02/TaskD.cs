using System;

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
            ThreadPool.SetMinThreads(1, 0); //We start with SetMin, because
                                            //"You cannot set the maximum number of worker threads or I/O completion 
                                            //threads to a number smaller than the number of processors on the 
                                            //computer."
                                            //And:
                                            //"You can't set the MaxThread smaller than MinThread"

            ThreadPool.SetMaxThreads(10, 0); //Sets the number of requests to the thread pool that can be active 
                                             //concurrently. All requests above that number remain queued until thread 
                                             //pool threads become available.

            var numbers = Enumerable.Range(1, 15);
            Parallel.ForEach(numbers, i =>
             {
                 Task.Factory.StartNew(() =>
                 {
                     Stopwatch stopWatch = new Stopwatch();
                     stopWatch.Start();

                     Console.WriteLine("Starting task" + i + " on thread " + Thread.CurrentThread.ManagedThreadId);
                     Thread.Sleep(1000);
                     TimeSpan ts = stopWatch.Elapsed;
                     string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                     ts.Hours, ts.Minutes, ts.Seconds,
                     ts.Milliseconds / 10);
                     Console.WriteLine("RunTime for task " + i + ": " + elapsedTime);
                 });
             });
        }
    }
}