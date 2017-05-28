
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
            Stopwatch sw = new Stopwatch();
            string[] urls = {
                "http://www.visualstudio.com",
                "http://www.microsoft.com",
                "http://www.google.com"
            };
            sw.Start();
            foreach (var url in urls)
            {
                var res = DownloadContentFromSite(url).Result;
                Console.WriteLine("Result was returned with length of {0} chars.", res.Length);
            }
            sw.Stop();
            Console.WriteLine($"Sequential: {sw.Elapsed}" + Environment.NewLine);
            sw.Restart();
            Parallel.ForEach(urls, url =>
            {
                var res = DownloadContentFromSite(url).Result;
                Console.WriteLine("Result was returned with length of {0} chars.", res.Length);
            });
            sw.Stop();
            Console.WriteLine($"Parallel: {sw.Elapsed}");
        }

        private static async Task<string> DownloadContentFromSite(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(url);
                Console.WriteLine($"Request was sent to {url}.");
                return result;
            }
        }
    }
}