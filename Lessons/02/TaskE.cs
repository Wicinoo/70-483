using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Declare an interface ISiteReader with a method ReadAsync(string requestUrl) that returns string in asynchronous way.
    /// Implement the interface and keep the asynchronous approach.
    /// Use await to call the method with "http://www.google.com" parameter.
    /// Print out the content of the page.
    /// </summary>
    public class TaskE
    {
        public static void Run()
        {
            var o = new SiteReader();
            var pageContent = o.ReadAsync("http://www.google.com");
            Console.WriteLine(pageContent.Result);
        }
    }

    interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }

    class SiteReader : ISiteReader
    {
        public async Task<string> ReadAsync(string requestUrl)
        {
            
            using (var webClient = new WebClient())
            {
                var taskResult = webClient.DownloadStringTaskAsync(requestUrl);
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("this code is running when page is downloading {0}", i);
                }

                var result = await taskResult;
                return result;
            }
        }
    }
}