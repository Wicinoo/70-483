using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        private static HttpClient _client = new HttpClient();

        public static void Run()
        {
            string[] sites = { "https://www.visualstudio.com/cs/", "https://www.microsoft.com/cs-cz/", "https://www.google.cz/", "https://www.behej.com/forum/nejnovejsi-prispevky" };

            Stopwatch sw = new Stopwatch();

            long elapsedAsync = 0;
            long elapsedSync = 0;
            int count = 10;

            for (int i = 0; i < count; i++)
            {
                elapsedSync += GetSites(sites, sw);
                elapsedAsync += GetSitesAsync(sites, sw);
            }

            Console.WriteLine($"GetSitesAsync average: {Convert.ToInt64(elapsedAsync / count)}");
            Console.WriteLine($"GetSitesSync average: {Convert.ToInt64(elapsedSync / count)}");
            Console.ReadKey();
        }

        
        private static long GetSitesAsync(string[] sites, Stopwatch sw)
        {
            sw.Reset();
            sw.Start();

            Task<Tuple<string, string>>[] tasks = new Task<Tuple<string, string>>[sites.Length];

            for (int i = 0; i < sites.Length; i++)
            {
                tasks[i] = GetSiteAsync(sites[i]);
            }

            Task.WaitAll(tasks);

            sw.Stop();
            Console.WriteLine($"GetSitesAsync, elapsed ms: {sw.ElapsedMilliseconds}");
            return sw.ElapsedMilliseconds;
        }

        private static long GetSites(string[] sites, Stopwatch sw)
        {
            sw.Reset();
            sw.Start();

            Tuple<string, string>[] tasks = new Tuple<string, string>[sites.Length];

            for (int i = 0; i < sites.Length; i++)
            {
                tasks[i] = GetSite(sites[i]);
            }

            sw.Stop();
            Console.WriteLine($"GetSites, elapsed ms: {sw.ElapsedMilliseconds}");
            return sw.ElapsedMilliseconds;
        }

        private static async Task<Tuple<string, string>> GetSiteAsync(string path)
        {
            string result = null;
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return new Tuple<string, string>(path, result);
        }

        private static Tuple<string, string> GetSite(string path)
        {
            string result = null;
            HttpResponseMessage response = _client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                result =  response.Content.ReadAsStringAsync().Result;
            }
            return new Tuple<string, string>(path, result);
        }
    }
}