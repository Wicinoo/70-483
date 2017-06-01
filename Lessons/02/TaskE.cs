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
            Task<string> result = reader.ReadAsync("http://www.seznam.cz");
            Console.WriteLine("some another work on main thread");
            Console.WriteLine(result.Result.Length);
        }
    }

    public interface ISiteReader
    {
         Task<string> ReadAsync(string requestUrl);
    }
    public class SiteReader : ISiteReader
    {
        public  async Task<string> ReadAsync(string requestUrl)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(requestUrl);
            }
        }
    }
}