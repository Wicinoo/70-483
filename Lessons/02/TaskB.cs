using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            var urls = new List<string> { "www.visualstudion.com", "www.microsoft.com", "www.google.com", "www.seznam.cz", "www.centrum.cz" };
            SequenceProcessing(urls);
            ParralelProcessingByThreads(urls);
            ParralelProcessingByThreadPool(urls);
            ParralelProcessingByTasks(urls);
            ParralelProcessingByTasksFactory(urls);
            ParralelProcessingByParallelForEach(urls);

        }

        private static void ParralelProcessingByTasksFactory(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Task parent = Task.Run(() =>
            {
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);
                foreach (var url in urls)
                {
                    tf.StartNew(() =>
                    {
                       _httpResult = GetHttpResult(url);
                    });
                }

                //return results;
            });
            parent.Wait();
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed.Milliseconds);
            //var finalTask = parent.ContinueWith(
            //parentTask => {
            //    foreach (int i in parentTask.Result)
            //        Console.WriteLine(i);
            //});
            //finalTask.Wait();
        }

        private static void ParralelProcessingByTasks(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Task[] tasks = new Task[urls.Count];
            for (int i = 0; i < urls.Count; i++)
            {
                var url = urls[i];        //we have to do it, because Task.Run consumes delegate. (we need add just a value to parameter)
                tasks[i] = Task.Run(() =>
                {
                   _httpResult = GetHttpResult(url);
                });
            }
            Task.WaitAll(tasks);
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed.Milliseconds);
        }

        private static void ParralelProcessingByThreadPool(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var events = new List<ManualResetEvent>();
            foreach (var url in urls)
            {
                var resetEvent = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem((s) =>
                {                  
                    _httpResult = GetHttpResult(url);
                    resetEvent.Set();
                });
                events.Add(resetEvent);
            }
            WaitHandle.WaitAll(events.ToArray());
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed.Milliseconds);
        }
        [ThreadStatic]
        public static string _httpResult;
        private static void ParralelProcessingByThreads(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            string[] result = new string[urls.Count];
            Thread[] threads = new Thread[urls.Count];
            stopWatch.Start();
            for (int i = 0; i < urls.Count; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(GetPok));
                threads[i].Start(urls[i]);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed.Milliseconds);

        }
        private static void GetPok(object urlAddress)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://" + urlAddress);
            var response = (HttpWebResponse)request.GetResponse();
            _httpResult = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
        private static void ParralelProcessingByParallelForEach(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Parallel.ForEach(urls, i =>
            {
                var urlResult = GetHttpResult(i);
            });
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name,stopWatch.Elapsed.Milliseconds);
        }

        private static void PrintResult(string methodName, int delay)
        {
            Console.WriteLine($"{methodName}: {delay}ms");
        }

        private static void SequenceProcessing(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var item in urls)
            {
                var urlResult = GetHttpResult(item);
            }
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed.Milliseconds);
        }

        private static string GetHttpResult(string urlAddress)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://" + urlAddress);
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}