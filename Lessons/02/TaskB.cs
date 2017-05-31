using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
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
            List<string> sites = new List<string> { "https://www.visualstudio.com", "https://www.microsoft.com", "https://www.google.com" };

            Stopwatch sw = new Stopwatch();

            sw.Start();
            sites.ForEach(web => PingWebsite(web));
            sw.Stop();
            Console.WriteLine("Sequential run: {0}", sw.ElapsedMilliseconds);

            sw.Restart();
            Parallel.ForEach(sites, web => PingWebsite(web));
            sw.Stop();

            Console.WriteLine("Parallel run: {0}", sw.ElapsedMilliseconds);
            //Console.ReadKey();

        }

        public static async void PingWebsite(string address)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(address);
                Console.WriteLine("Request was sent. Result: {1}", result );
            }
        }
    }
}