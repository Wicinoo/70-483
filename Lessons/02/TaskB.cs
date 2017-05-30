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
        private static string[] _pagesToAccess = new string[] { "http://www.microsoft.com", "http://www.microsoft.com", "http://www.microsoft.com", "http://www.microsoft.com", "http://www.microsoft.com", "http://www.google.com", "http://www.visualstudio.com" };

        public static void Run()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(_pagesToAccess, website =>
            {
                Console.WriteLine(Download(website).Length + "b");               
            });

            Task.WaitAll();
            stopwatch.Stop();
            Console.WriteLine("Async took " + stopwatch.ElapsedMilliseconds + " milliseconds.");
            Console.WriteLine(String.Empty);

            stopwatch.Reset();
            stopwatch.Start();
            foreach (string website in _pagesToAccess)
            {
                Console.WriteLine(Download(website).Length + "b");
            }
            stopwatch.Stop();
            Console.WriteLine("Sync took " + stopwatch.ElapsedMilliseconds + " milliseconds.");
        }

        private static string Download(string website)
        {
            using (WebClient client = new WebClient())
            {
                string result = client.DownloadString(website);
                return result;
            }
        }
    }
}