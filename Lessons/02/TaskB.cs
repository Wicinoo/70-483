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
            var timer = new Stopwatch();
            var urls = new[] { "www.visualstudio.com", "www.microsoft.com", "www.google.com" };
            
            timer.Start();
            ProcessSequential(urls);
            timer.Stop();
            Console.WriteLine("sequential {0} ms", timer.ElapsedMilliseconds);

            timer.Reset();
            timer.Start();
            ProcessParallel(urls);
            timer.Stop();
            Console.WriteLine("parallel {0} ms", timer.ElapsedMilliseconds);
        }

        private static void ProcessSequential(string[] urls)
        {
            foreach (var url in urls)
            {
                var content = DownloadContentFromWebSite(url);
            }
        }
        
        private static void ProcessParallel(string[] urls)
        {
            Parallel.ForEach(
                urls,
                url => { var content = DownloadContentFromWebSite(url); });
        }

        private static string DownloadContentFromWebSite(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetStringAsync("http://" + url);
                return result.Result;
            }
        }
    }
}