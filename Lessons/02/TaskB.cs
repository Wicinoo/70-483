using System;
using System.Diagnostics;
using System.Net.Http;
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
        private static string[] sites = new string[] { "www.visualstudio.com", "www.microsoft.com", "www.google.com" };

        public static void Run()
        {
            Task<long> result = Task.Run(()=> ReadSitesSequentially());
            Console.WriteLine($"Sequential reading took: {result?.Result} milliseconds");

            long result2 = ReadSitesParallely();
            Console.WriteLine($"Sequential reading took: {result2} milliseconds");
        }

        private static async Task<long> ReadSitesSequentially()
        {
            Console.WriteLine("Reading sites sequentially.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (HttpClient client = new HttpClient())
            {
                foreach (string site in sites)
                {
                    var response = await client.GetStringAsync($"http://{site}");
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static long ReadSitesParallely()
        {
            Console.WriteLine("Reading sites parallely.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.ForEach(sites, site =>
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetStringAsync($"http://{site}");
                }
            });

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}