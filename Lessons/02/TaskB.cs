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
        public static void Run()
        {
            var sites = new[] {"http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com"};

            MeasureAndPrintActionDuration("Sequential Processing", () => ReadSitesSequentially(sites));

            MeasureAndPrintActionDuration("Parallel Processing", () => ReadSitesParallely(sites));
        }

        private static void MeasureAndPrintActionDuration(string actionName, Action action)
        {
            var s = new Stopwatch();

            s.Start();

            action();

            s.Stop();

            Console.WriteLine($"{actionName}: {s.Elapsed}");
        }

        private static void ReadSitesSequentially(string[] sites)
        {
            foreach (var site in sites)
            {
                ReadSite(site);
            }
        }

        private static void ReadSite(string site)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.GetStringAsync(site).Wait();
            }
        }

        private static void ReadSitesParallely(string[] sites)
        {
            Parallel.ForEach(sites, ReadSite);
        }
    }
}