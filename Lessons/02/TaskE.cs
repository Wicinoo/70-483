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
        
        public async static void Run()
        {
            var sitereader = new SiteReader();
            var response = await sitereader.ReadAsync("http://www.google.com");

            Console.WriteLine(response);
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
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(requestUrl);
                Console.WriteLine("Request was sent async.");
                return result;
            }
        }
    }

}