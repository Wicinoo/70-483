using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;


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
            Stopwatch stopwatch = new Stopwatch();

            List<string> websites = new List<string> { "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" };

            stopwatch.Start();
            websites.ForEach(x => GetWebsite(x));
            stopwatch.Stop();

            Console.WriteLine("Elapsed miliseconds sequential: {0}", stopwatch.ElapsedMilliseconds);


            stopwatch.Reset();
            stopwatch.Start();
            Parallel.ForEach(websites, x => GetWebsite(x));
            stopwatch.Stop();
            
            //somehow parallel processing is slower than sequential...
            Console.WriteLine("Elapsed miliseconds parallel: {0}", stopwatch.ElapsedMilliseconds);

        }


        public static async void GetWebsite(string url)
        {
            HttpClient httpClient = new HttpClient();
            var siteData = await httpClient.GetStringAsync(url);
            Console.WriteLine("Site {0} fetched. Data length: {1}", url, siteData.Length); 
        }
    }
}