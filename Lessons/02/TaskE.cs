using System;
using System.Net;
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
        protected static string GoogleUrl = "http://www.google.com";

        public static void Run()
        {
            CallAsyncMethod();

        }

        private static async void CallAsyncMethod()
        {
            var reader = new SiteReader();

            Console.WriteLine("Calling...");
            var pageContent = await reader.ReadAsync(GoogleUrl);

            Console.WriteLine("Result: ");
            Console.WriteLine(pageContent);
        }

        public class SiteReader : ISiteReader
        {
            public Task<string> ReadAsync(string requestUlr)
            {
                Task<string> t = Task.Run(() =>
                {
                    using (WebClient client = new WebClient())
                    {
                        var result = client.DownloadString(requestUlr);
                        return result;
                    }
                });

                return t;
            }
        }

        public interface ISiteReader
        {
            Task<string> ReadAsync(string requestUlr);
        }
    }
}