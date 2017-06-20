using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

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
            var sequentialDuration = GetSequantialDuration();
            var parallelDuration = GetParallelDuration();

            Console.WriteLine($"Sequential duration: {sequentialDuration} ms");
            Console.WriteLine($"Parallel duration: {parallelDuration} ms");
        }

        private static long GetParallelDuration()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var thread1 = new Thread(() => ReadSite("http://www.visualstudio.com"));
            var thread2 = new Thread(() => ReadSite("http://www.microsoft.com"));
            var thread3 = new Thread(() => ReadSite("http://www.google.com"));

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        private static long GetSequantialDuration()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            ReadSite("http://www.visualstudio.com");
            ReadSite("http://www.microsoft.com");
            ReadSite("http://www.google.com");

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        private static void ReadSite(string url)
        {
            using (var client = new WebClient())
            {
                client.DownloadString(url);
            }
        }
    }
}