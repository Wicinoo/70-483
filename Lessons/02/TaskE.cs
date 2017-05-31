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
            ReadSite rs = new ReadSite();

            Task<string> result = rs.ReadAsync("http://www.google.com");

            Console.WriteLine(result);
        }

        public interface ISiteReader
        {
            Task<string> ReadAsync(string address);
        }


        public class ReadSite : ISiteReader
        {
            public HttpClient hc;

            public ReadSite()
            {
                hc = new HttpClient();
            }

            public async Task<string> ReadAsync(string address)
            {
                return await hc.GetStringAsync(address);
            }
        }

    }
}