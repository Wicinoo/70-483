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
        public static void Run()
        {
            ISiteReader siteReader = new SiteReader();
            Console.WriteLine(siteReader.ReadAsync("http://www.google.com").Result);
        }
    }

    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }

    public class SiteReader : ISiteReader
    {
        private HttpClient _client;

        public SiteReader()
        {
            _client = new HttpClient();
        }

        public async Task<string> ReadAsync(string requestUrl)
        {
            HttpResponseMessage response = await _client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}