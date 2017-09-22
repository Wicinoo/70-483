using System;
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
        public static void Run()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var vs1 = DownloadContent(@"http://www.visualstudio.com");
            var ms1 = DownloadContent(@"https://www.microsoft.com");
            var goog1 = DownloadContent(@"https://www.google.com");

            Console.WriteLine($"First characters of response: {vs1[0]}, {ms1[0]}, {goog1[0]}.");
            stopwatch.Stop();

            Console.WriteLine($"Sequentially elapsed {stopwatch.ElapsedMilliseconds} ms.");

            stopwatch.Reset();
            stopwatch.Start();
            var vs2 = DownloadContentAsync(@"https://www.visualstudio.com");
            var ms2 = DownloadContentAsync(@"https://www.microsoft.com");
            var goog2 = DownloadContentAsync(@"https://www.google.com");

            Console.WriteLine($"First characters of response: {vs2.Result[0]}, {ms2.Result[0]}, {goog2.Result[0]}.");
            stopwatch.Stop();
            Console.WriteLine($"Parralel elapsed {stopwatch.ElapsedMilliseconds} ms.");
        }

        public static string DownloadContent(string address)
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadString(address);
                Console.WriteLine("Request was sent.");
                return result;
            }
        }

        public static async Task<string> DownloadContentAsync(string address)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(address);
                Console.WriteLine("Request was sent async.");
                return result;
            }
        }
    }
}