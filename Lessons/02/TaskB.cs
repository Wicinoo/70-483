using System;
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
        public static void Run()
        {
            var clockDevice = new Stopwatch();


            clockDevice.Start();
            Task<string> sequential1 = DownloadContentSite("http://www.visualstudio.com");
            sequential1.Wait();
            Task<string> sequential2 = DownloadContentSite("http://www.microsoft.com");
            sequential2.Wait();
            Task<string> sequential3 = DownloadContentSite("http://www.google.com");
            sequential3.Wait();
            clockDevice.Stop();

            Console.WriteLine("Sequential took " + clockDevice.Elapsed.TotalMilliseconds + "miliseconds");


            clockDevice.Restart();
            Task<string> parallel1 = DownloadContentSite("http://www.visualstudio.com");
            Task<string> parallel2 = DownloadContentSite("http://www.microsoft.com");
            Task<string> parallel3 = DownloadContentSite("http://www.google.com");
            Task.WaitAll(parallel1, parallel2, parallel3);
            clockDevice.Stop();

            Console.WriteLine("Parallel took " + clockDevice.Elapsed.TotalMilliseconds + "miliseconds");

        }


        private static async Task<string> DownloadContentSite(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(url);
                return result;
            }
        }
    }
}