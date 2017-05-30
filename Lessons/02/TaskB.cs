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
        public static void Run()         {
            Stopwatch stopwatch = new Stopwatch();
            List<String> websites = new List<String> { "http://www.visualstudio.com", "http://www.microsoft.com", "http://www.google.com" };

            stopwatch.Start();
            foreach (String site in websites) {
                GetWebsiteContent(site);
            }
            stopwatch.Stop();

            Console.WriteLine("Sequential run took: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();

            stopwatch.Start();
            websites.AsParallel<String>().ForAll(x => GetWebsiteContent(x));
            stopwatch.Stop();

            Console.WriteLine("Paranormal run took: {0} ms", stopwatch.ElapsedMilliseconds);
        }


        public static async void GetWebsiteContent(String url) {
            HttpClient httpClient = new HttpClient();
            var siteData = await httpClient.GetStringAsync(url);

            Console.WriteLine("Loading of {0} completed. Recieved {1} characters.", url, siteData.Length); 
        }
    }
}