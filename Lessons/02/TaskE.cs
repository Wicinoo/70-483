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


    public class TaskE {
        public static async void Run() {
            AsyncSiteReader asyncSiteReader = new AsyncSiteReader();
            String address = "https://www.google.com/search?q=if+you+type+google+into+google&hl=cs&source=lnms&sa=X&ved=0ahUKEwjp6cf3tJjUAhVClxoKHaZLD2gQ_AUIBSgA&biw=1280&bih=696&dpr=1";

            String content = await asyncSiteReader.ReadAsync(address);

            Console.WriteLine("Lync 1.12 Beta | Google.com loaded");
            Console.WriteLine(content);
        }
    }

    public interface ISiteReader {
        Task<string> ReadAsync(String requestUrl);
    }


    public class AsyncSiteReader : ISiteReader {
        private HttpClient httpClient;

        public AsyncSiteReader()         {
            httpClient = new HttpClient();
        }

        public Task<string> ReadAsync(String address) {
            return httpClient.GetStringAsync(address);
        }
    }
}