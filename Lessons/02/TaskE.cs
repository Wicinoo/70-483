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
        public static void Run()
        {
            ISiteReader reader = new SiteReader();
            Console.WriteLine(reader.ReadAsync("http://www.google.com").Result);
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

            WebClient client = new WebClient();
            Task<string> task = Task.Run(() => client.DownloadString(requestUrl));

            return await task;
        }
    }
}