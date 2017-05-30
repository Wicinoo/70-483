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
            var siteReader = new SiteReader();
            var result = await siteReader.ReadAsync("http://www.google.com");
            Console.WriteLine(result);
        }
    }

    interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }

    class SiteReader : ISiteReader
    {
        public Task<string> ReadAsync(string requestUrl)
        {
            var client = new HttpClient();
            return client.GetStringAsync(requestUrl);
        }
    }
}