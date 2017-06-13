using System;
using System.Net.Http;
using System.Threading.Tasks;
using Rhino.Mocks.Constraints;

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
        public static async Task Run()
        {
            var reader = new SiteReader();

            var pageContent = await reader.ReadAsync("http://www.google.com");

            Console.WriteLine("Page content: {0}", pageContent);
        }
    }

    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }

    public class SiteReader : ISiteReader
    {
        public async Task<string> ReadAsync(string requestUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(requestUrl);
                Console.WriteLine("Request was sent.");
                return result;
            }
        }
    }
}