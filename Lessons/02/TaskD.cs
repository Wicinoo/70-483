using System;
using System.Collections.Generic;
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
        private const int numberOfTask = 15;
        private Stopwatch[] results = new Stopwatch[numberOfTask];
        public void Run()
        {
            ThreadPool.SetMaxThreads(10,10);
               
            Task[] tasks = new Task[numberOfTask];
            for (int i = 0; i < numberOfTask; i++)
            {
                var item = i;
                results[i] = new Stopwatch();
                results[i].Start();
                tasks[i] = Task.Run(() => TaskWork(item));
            }

            Task.WaitAll(tasks);
            PrintResult(results);
        }

        

        private void PrintResult(Stopwatch[] stopwatches)
        {
            foreach (var stopWatch in stopwatches)
            {
                Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            }
        }

        private void TaskWork(int item)
        {
            
            Thread.Sleep(1000);
            results[item].Stop();
        }
    }
}