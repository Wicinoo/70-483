using System;
using System.Threading;

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
            var content = reader.ReadAsync("http://www.google.com");
            while (content.Status != System.Threading.Tasks.TaskStatus.RanToCompletion)
            {
                Console.Clear();
                Console.WriteLine("Downloading");
                Thread.Sleep(20);
            }

            Console.WriteLine(content.Result);
        }
    }
}