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
            ISiteReader reader = new SiteReader();

            Console.WriteLine("Google feed started!");
            Task<string> googleReadingTask = reader.ReadAsync("http://www.google.com");

            Console.WriteLine("Program is doing other stuff!");
                       
            Console.WriteLine($"Google feed finished. Lenght of the page is {googleReadingTask.Result.Length}b.");
        }
    }

    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }

    public class SiteReader : ISiteReader
    {
        public Task<string> ReadAsync(string requestUrl)
        {
            Task<string> websiteReader = Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    return await client.GetStringAsync(requestUrl);
                }
            });

            return websiteReader;
        }
    }
}