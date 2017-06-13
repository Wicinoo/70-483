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
        private static readonly List<string> sites = new List<string>{ "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" };
        public static void Run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            sites.ForEach(DownloadFromSite);
            watch.Stop();

            Console.WriteLine("Sequential: {0}",watch.ElapsedMilliseconds);

            watch.Restart();
            watch.Start();
            Parallel.ForEach(sites, DownloadFromSite);
            watch.Stop();

            Console.WriteLine("Parallel: {0}", watch.ElapsedMilliseconds);
        }

        private async static void DownloadFromSite(string site)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.GetStringAsync(site);
                Console.WriteLine("Site: {0}",site);
            }
        }
    }
}