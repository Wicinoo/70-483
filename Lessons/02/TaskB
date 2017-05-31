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
        private static Uri[] _sites = { new Uri("http://www.visualstudio.com"), new Uri("http://www.microsoft.com"), new Uri("http://www.google.com") };

        private static Stopwatch _stopwatch = new Stopwatch();
        public static void Run()
        {
            _stopwatch.Restart();
            foreach (var site in _sites)
            {
                GetWeb(site);
            }
            _stopwatch.Stop();
            Console.WriteLine("time:"+ _stopwatch.ElapsedMilliseconds);

            _stopwatch.Restart();
            Parallel.ForEach(_sites, x => GetWeb(x));
            _stopwatch.Stop();
            Console.WriteLine("time:" + _stopwatch.ElapsedMilliseconds);

        }

        private static async void GetWeb(Uri url)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                Console.WriteLine(url.AbsoluteUri + ": " + result.Length);
            }
        }

    }
}
