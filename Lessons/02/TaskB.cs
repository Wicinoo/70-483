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
        private static  List<string> _urls = new List<string> { "https://www.visualstudio.com", "https://www.microsoft.com", "https://www.google.com" };
        public static void Run()
        {
            ReadWebsitesSequentially();
            ReadWebsitesInParallel();
        }

        private static void ReadWebsitesSequentially()
        {
            var task = Task.Run(async () =>
            {
                foreach (var url in _urls)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        await ReadWebsite(client, url, "Sequential");
                    }
                }
            });
        }

        private static void ReadWebsitesInParallel()
        {
            Parallel.ForEach(_urls, async url =>
            {
                using (HttpClient client = new HttpClient())
                {
                    await ReadWebsite(client, url, "Parallel");
                }
            });
        }

        private static async Task ReadWebsite(HttpClient client, string url, string process)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await client.GetStringAsync(url);
            Console.WriteLine("{0} Website: {1} Duration: {2} seconds",process, url, stopWatch.Elapsed.TotalSeconds);
        }

   
    }
}