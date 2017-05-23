using System;
using System.Threading.Tasks;
using System.Net.Http;
namespace Lessons._02
{
    /// <summary>
    /// Declare an interface ISiteReader with a method ReadAsync(string requestUrl) that returns string in asynchronous way.
    /// Implement the interface and keep the asynchronous approach.
    /// Use await to call the method with "http://www.google.com" parameter.
    /// Print out the content of the page.
    /// </summary>
    /// 


    public class TaskE
    {
        private const bool homeAlone = false;

        public static async void Run()
        {
            var asyncSiteReader = new AsyncSiteReader();

            var site = homeAlone ? "http://pornhub.com" : "http://www.google.com";

            var siteData = await asyncSiteReader.ReadAsync(site);

            Console.WriteLine("Site data: {0}", siteData);
        }
    }

    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }


    public class AsyncSiteReader : ISiteReader
    {
        private HttpClient httpClient;

        public AsyncSiteReader()
        {
            httpClient = new HttpClient();
        }

        public Task<string> ReadAsync(string requestUrl)
        {
            return httpClient.GetStringAsync(requestUrl);
        }
    }
}