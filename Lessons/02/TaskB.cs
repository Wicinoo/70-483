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
        protected static Stopwatch watch = new Stopwatch();

        public static void Run()
        {
            var urls = new List<string>
            {
                "www.visualstudio.com",
                "www.microsoft.com",
                "www.google.com"
            };

            Console.WriteLine("Sequential processing");

            ProcessSequentially(urls);

            Console.WriteLine("Parallel processing");

            ProcessParallely(urls);
        }

        //code duplication can be reworked to pass method delegate
        public static void ProcessSequentially(IEnumerable<string> urlsToProcess)
        {
            var s = new Stopwatch();
            s.Start();
            //foreach
            foreach (var url in urlsToProcess)
            {
                ReadUrl(url);
            }
            s.Stop();
            Console.WriteLine("Stopwatch result: {0}", s.ElapsedMilliseconds);
        }

        public static void ProcessParallely(IEnumerable<string> urlsToProcess)
        {
            var s = new Stopwatch();
            s.Start();
            //using pararell
            Parallel.ForEach(urlsToProcess, ReadUrl);
            s.Stop();
            Console.WriteLine("Stopwatch result: {0}", s.ElapsedMilliseconds);
        }

        public static void ReadUrl(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.GetStringAsync(string.Format("http://{0}",url)).Wait();
            }
        }
    }
}