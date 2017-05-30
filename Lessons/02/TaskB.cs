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
        private static readonly string[] Urls =
            {
                "http://www.visualstudio.com",
                "http://www.microsoft.com",
                "http://www.google.com",
                "https://www.reddit.com",
                "https://github.com/",
                "https://eksisozluk.com/"
            };

        private static string InfoDisplayFormat = "Url : {0} , Length : {1}";

        private static Stopwatch _stopwatch = new Stopwatch();


        public static void Run()
        {
            ReadSitesSequential();
            Console.WriteLine();
            ReadSitesParallel();
        }

        private static void ReadSitesParallel()
        {
            _stopwatch.Reset();
            _stopwatch.Start();

            var httpClient = new HttpClient();

            Console.WriteLine("*** Starting Parallel Read");

            Parallel.For(0, Urls.Length, index =>
            {
                var content = httpClient.GetStringAsync(Urls[index]);
                Console.WriteLine(InfoDisplayFormat, Urls[index], content.Result.Length);
            });

            Console.WriteLine("*** End of Parallel Read");
            Console.WriteLine("Parallel Read Time : {0}", _stopwatch.Elapsed);
        }

        private static void ReadSitesSequential()
        {
            _stopwatch.Start();

            Console.WriteLine("*** Starting Sequential Read");

            var httpClient = new HttpClient();

            foreach (var url in Urls)
            {
                var content = httpClient.GetStringAsync(url);
                Console.WriteLine(InfoDisplayFormat, url, content.Result.Length);
            }
            Console.WriteLine("*** End of Sequential Read");

            _stopwatch.Stop();
            Console.WriteLine("Sequential Read Time : {0}", _stopwatch.Elapsed);
        }
    }
}