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
    public class TaskE : ISiteReader
    {
        public static void Run()
        {
            var task = new TaskE();
            Console.WriteLine(task.ReadAsync("http://www.google.com"));
        }

        public string ReadAsync(string requestUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                return ReadWebsite(client, requestUrl).Result;
            }
        }

        private static async Task<string> ReadWebsite(HttpClient client, string url)
        {
            var webData = await client.GetStringAsync(url);
            return webData;
        }
    }

    public interface ISiteReader
    {
         string ReadAsync(string requestUrl);
    }
}