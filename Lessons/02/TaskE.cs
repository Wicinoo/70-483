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
            var sr = new SiteReader();
            var content = await sr.ReadAsync("http://www.google.com");
            Console.WriteLine("Content Length : {0}", content.Length);
            Console.WriteLine(content.Substring(0, content.Length / 100));
        }
    }

    public class SiteReader : ISiteReader
    {
        public async Task<string> ReadAsync(string requestUrl)
        {
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(requestUrl);
        }
    }

    interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }
}