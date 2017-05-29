using System;
using System.Net.Http;
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
        public interface ISiteReader
        {
            Task<string> ReadAsync(string requestUrl);
        }

        public class SiteReader : ISiteReader
        {
            public async Task<string> ReadAsync(string requestUrl)
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetStringAsync(requestUrl);

                    return result;
                }
            }
        }

        public static void Run()
        {
            var siteReader = new SiteReader();

            var siteContent = siteReader.ReadAsync("http://www.google.com").Result;
            Console.WriteLine(siteContent);
        }
    }
}