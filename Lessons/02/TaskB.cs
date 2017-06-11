using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            var client = new WebClient();
            var text = client.DownloadString("https://www.microsoft.com");
            Console.Write(text);
        }
    }
}