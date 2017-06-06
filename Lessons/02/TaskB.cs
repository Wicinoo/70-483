using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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
            GetPagesContentSequentially();
            GetPagesContentInParallel();
        }

        public static void GetPagesContentSequentially()
        {
            var stopWatch = Stopwatch.StartNew();

            var httpClient = new HttpClient();

            Task task = Task.Run(() =>
            {
                var webTask = httpClient.GetStringAsync("http://www.visualstudio.com");
            }).ContinueWith((prev) =>
            {
                var webData = httpClient.GetStringAsync("http://www.microsoft.com");
            }).ContinueWith((prev) =>
            {
                var webData = httpClient.GetStringAsync("http://www.google.com");
            });

            task.Wait();

            Console.WriteLine($"Sequentail runtime: {stopWatch.Elapsed.TotalSeconds} seconds");
        }

        public static void GetPagesContentInParallel()
        {
            var stopWatch = Stopwatch.StartNew();

            var httpClient = new HttpClient();

            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() => {
                var webTask = httpClient.GetStringAsync("http://www.visualstudio.com");
            });
            tasks[1] = Task.Run(() => {
                var webData = httpClient.GetStringAsync("http://www.microsoft.com");
            });
            tasks[2] = Task.Run(() => {
                var webData = httpClient.GetStringAsync("http://www.google.com");
            });

            Task.WaitAll(tasks);

            Console.WriteLine($"Parallel runtime: {stopWatch.Elapsed.TotalSeconds} seconds");
        }
    }
}