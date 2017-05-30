using System;
using System.Collections.Generic;
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
        protected static Stopwatch Stopwatch = new Stopwatch();
        protected static List<string> Urls = new List<string>
            {
                "http://www.visualstudio.com",
                "http://www.microsoft.com",
                "http://www.google.com"
            };

        protected static List<string> Results = new List<string>();


        public static void Run()
        {
            ReadSeq();

            ReadParrael();
        }

        private static void ReadParrael()
        {
            Results.Clear();
            Console.WriteLine($"Starting parrael - Result count: {Results.Count}");
            Stopwatch.Restart();

            using (HttpClient client = new HttpClient())
            {
                Parallel.ForEach(Urls, url =>
                {
                    var result = client.GetStringAsync(url);
                    Results.Add(result.Result);
                });
            }

            Stopwatch.Stop();

            Console.WriteLine($"Result count: {Results.Count}");
            Console.WriteLine($"Seq Elapsed miliseconds: {Stopwatch.ElapsedMilliseconds}");
        }

        private static void ReadSeq()
        {
            Stopwatch.Restart();

            using (HttpClient client = new HttpClient())
            {
                foreach (var url in Urls)
                {
                    var result = client.GetStringAsync(url);
                    Results.Add(result.Result);
                }
            }

            Stopwatch.Stop();

            Console.WriteLine($"Result count: {Results.Count}");
            Console.WriteLine($"Seq Elapsed miliseconds: {Stopwatch.ElapsedMilliseconds}");
        }
    }
}