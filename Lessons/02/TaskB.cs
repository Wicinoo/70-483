using System;
using System.Collections.Generic;
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
        private static IEnumerable<string> _sites = new List<string> {"http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com"};

        public static void Run()
        {
            SequentialProcessing();
            ParallelProcessing();
        }

        private static void SequentialProcessing()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var site in _sites)
            {
                var result = DownloadContent(site).Result;
            }

            stopwatch.Stop();

            Console.WriteLine("sequential:");
            WriteResult(stopwatch.ElapsedTicks);
        }

        private static void ParallelProcessing()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.ForEach(_sites, (site) =>
            {
                var result = DownloadContent(site);
            });

            stopwatch.Stop();

            Console.WriteLine("parallel: ");
            WriteResult(stopwatch.ElapsedTicks);
        }

        private async static Task<string> DownloadContent(string site)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(site);
            }
        }

        private static void WriteResult(long elapsed)
        {
            Console.WriteLine(elapsed);
        }
    }
}