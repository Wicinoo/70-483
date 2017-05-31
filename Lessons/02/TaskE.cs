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
        public static async void Run()
        {
            string site = await new SiteReader().ReadAsync("http://www.google.com");
            Console.WriteLine(site);
        }
    }

    public class SiteReader : ISiteReader
    {
        private HttpClient _client = new HttpClient();

        public Task<string> ReadAsync(string requestUrl)
        {
            return _client.GetStringAsync(requestUrl);
        }
    }

    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }
}
