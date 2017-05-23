using System;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Collections.Generic;
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
            var url = new List<string>() { "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" };

            var watch = new Stopwatch();
            watch.Start();
            url.ForEach(x => ReadPage(x));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch.Reset();
            watch.Start();
            Parallel.ForEach(url, x => ReadPage(x));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }

        public static void ReadPage(string url)
        {            
            using (WebClient client = new WebClient())
            {
                var result = client.DownloadString(url);
                Console.WriteLine("page {0} is loaded", url);
            }            
        }
    }
}