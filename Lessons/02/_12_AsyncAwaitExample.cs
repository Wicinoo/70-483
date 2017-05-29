using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _12_AsyncAwaitExample
    {
        public static void Run()
        {
            Task<string> result = DownloadContentFromMicrosoftSite();

            Console.WriteLine("Processing after request and before getting result.");
            Console.WriteLine("Result was returned with length of {0} chars.", result.Result.Length);
        }

        private static async Task<string> DownloadContentFromMicrosoftSite()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                Console.WriteLine("Request was sent.");
                return result;
            }
        }

        public static void RunWithAnonymousMethod()
        {
            Task<string> siteContentTask = Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync("http://www.microsoft.com");
                }
            });

            Console.WriteLine("Result was returned with length of {0} chars.", siteContentTask.Result.Length);
        }
    }
}