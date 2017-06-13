using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        protected static Stopwatch watch = new Stopwatch();

        public static void Run()
        {
            var urls = new List<string>
            {
                "www.visualstudio.com",
                "www.microsoft.com",
                "www.google.com"
            };

            Console.WriteLine("Sequential processing");



            Console.WriteLine("Parallel processing");
        }
    }
}