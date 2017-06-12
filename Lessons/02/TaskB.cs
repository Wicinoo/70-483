using System;
using System.Diagnostics;
using System.Net;
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
            var urls = new string[] { "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" };
            var client = new WebClient();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (string url in urls)
            {
                client.DownloadString(url);
            }
            stopWatch.Stop();
            TimeSpan elapsed = stopWatch.Elapsed;
            Console.WriteLine(String.Format("{0:00}:{1:0000}", elapsed.Seconds, elapsed.Milliseconds));

            stopWatch.Start();
            Parallel.ForEach(urls, url =>
            {
                var client2 = new WebClient();
                client2.DownloadString(url);
            });
            stopWatch.Stop();
            TimeSpan elapsed2 = stopWatch.Elapsed;
            Console.WriteLine(String.Format("{0:00}:{1:0000}", elapsed2.Seconds, elapsed2.Milliseconds));
            Console.ReadKey();
        }
    }
}