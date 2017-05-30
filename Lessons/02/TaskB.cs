using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
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
        private static List<string> urls = new List<string> { "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" };
        public static void Run()
        {
            var stopwatch = new Stopwatch();

            var pages = new Dictionary<string, string>();
            stopwatch.Start();
            foreach (var url in urls)
            {
                using (var wc = new WebClient())
                {
                    pages[url] = wc.DownloadString(url);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Sequential download took: {stopwatch.Elapsed}.");

            var pagesC = new ConcurrentDictionary<string, string>();
            stopwatch.Restart();
            Parallel
                .ForEach(
                    urls,
                    url =>
                    {
                        using (var wc = new WebClient())
                        {
                            pagesC[url] = wc.DownloadString(url);
                        }
                    }
                );
            stopwatch.Stop();
            Console.WriteLine($"Parallel download took: {stopwatch.Elapsed}.");
        }
    }
}