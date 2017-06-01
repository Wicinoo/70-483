using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        [ThreadStatic]
        public static string _httpResult;

        public static void Run()
        {
            var urls = new List<string> { "www.visualstudion.com", "www.microsoft.com", "www.google.com", "www.seznam.cz", "www.centrum.cz" };
            //SequenceProcessing(urls);
            //ParralelProcessingByThreads(urls);
            //ParralelProcessingByThreadPool(urls);
            //ParralelProcessingByTasks(urls);

            ParralelProcessingByTaskWhatUsesTasksFactory(urls);
            
            //ParralelProcessingByTasksFactorySingleVersion(urls);
            //ParralelProcessingByParallelForEach(urls);
            //ParallelProcessingByParallelFor(urls);
            //ParallelProcessingByAsyncAwait(urls);
        }

        private static void ParallelProcessingByAsyncAwait(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Task[] results = new Task[urls.Count];
            for (int i = 0; i < urls.Count; i++)
            {
                var urlLocal = urls[i];
                results[i] = GetHttpResultAsync(urlLocal);
            }
            PrintResult(MethodBase.GetCurrentMethod().Name + " I/O bond operation takes", stopWatch.Elapsed);
            Task.WaitAll(results);
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }

        private static void ParralelProcessingByTasksFactorySingleVersion(List<string> urls)
        {
            var results = new string[urls.Count];

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Task[] tasks = new Task[urls.Count];

            for (int i = 0; i < urls.Count; i++)
            {
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);

                var url = urls[i];
                var resultItem = i;
                tasks[i] = tf.StartNew(() =>
                {
                    results[resultItem] = GetHttpResult(url);
                });
            }
            //if we use resultTask.Result, this is the same like wait 
            Task.WaitAll(tasks);
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }

        private static void ParralelProcessingByTaskWhatUsesTasksFactory(List<string> urls)
        {
           
            var events = new ManualResetEvent[urls.Count];
            for (var i = 0; i < urls.Count; i++)
            {
                events[i] = new ManualResetEvent(false);
            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Task<string[]> parentTask = Task.Run(() =>
            {
                var results = new string[urls.Count];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                   TaskContinuationOptions.ExecuteSynchronously);
                for (var i = 0; i < urls.Count; i++)
                {
                    var url = urls[i];
                    var resultItem = i;

                    tf.StartNew(() =>
                    {
                        results[resultItem] = GetHttpResult(url);
                        events[resultItem].Set();
                    });
                }

                return results;
            });


            //didn't work
            //var finalTask = parentTask.ContinueWith(parent =>
            //    {
            //        foreach (string particularTaskResult in parent.Result)
            //        {
            //            Console.WriteLine(particularTaskResult.Length);
            //        }
            //    }, TaskContinuationOptions.OnlyOnRanToCompletion);
            //finalTask.Wait();

            //parentTask.Wait(); // doesn't work - why? the child threads is attached to parent
            var handles = events.ToArray();
            WaitHandle.WaitAll(handles);

            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
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
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }

        private static void ParralelProcessingByThreadPool(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var events = new List<WaitHandle>();
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
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }
       
        private static void ParralelProcessingByThreads(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            string[] result = new string[urls.Count];
            Thread[] threads = new Thread[urls.Count];
            stopWatch.Start();
            for (int i = 0; i < urls.Count; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(GetHttpResult2)); //delegate must have void MethodName(object) signature
                threads[i].Start(urls[i]);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);

        }
        private static void GetHttpResult2(object urlAddress)
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
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }

        private static void ParallelProcessingByParallelFor(List<string> urls)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ParallelLoopResult result = Parallel.For(0, urls.Count, (int i, ParallelLoopState loopState) =>
            {
                var urlResult = GetHttpResult(urls[i]);
            });
            stopWatch.Stop();
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }
        private static void PrintResult(string methodName, TimeSpan timeSpan)
        {
            Console.WriteLine($"{methodName}: {timeSpan.TotalSeconds}ms");
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
            PrintResult(MethodBase.GetCurrentMethod().Name, stopWatch.Elapsed);
        }

        private static string GetHttpResult(string urlAddress)
        {
            Thread.Sleep(1000);
            return "test";
            //var request = (HttpWebRequest)WebRequest.Create("http://" + urlAddress);
            //var response = (HttpWebResponse)request.GetResponse();
            //return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private static async Task<string> GetHttpResultAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine($"start with {url}");
                string result = await client.GetStringAsync("http://" + url);
                Console.WriteLine($"we have result for {url}");
                return result;
            }
        }
    }
}