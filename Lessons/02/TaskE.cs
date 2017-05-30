using System;

namespace Lessons._02
{
    using System.Net.Configuration;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Rhino.Mocks.Constraints;

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
            Console.WriteLine("Task E start");
            var reader = new SiteReader();

            reader.ReadAsync("http://www.google.com").ContinueWith((s) => Console.WriteLine(s.Result));

            Console.WriteLine("Waiting for async triggered Reader");
        }

        public class SiteReader : ISiteReader
        {
            public async Task<string> ReadAsync(string requestUrl)
            {
                using (HttpClient client = new HttpClient())
                {

                    string content = await client.GetStringAsync(requestUrl);
                    Thread.Sleep(3000);
                    return content;
                }
            }
        }


        public interface ISiteReader
        {
            Task<string> ReadAsync(string requestUrl);
        }
    }
}