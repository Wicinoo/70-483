using System;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var thread = new Thread(new ThreadStart(PrintThreadContext));
            thread.Start();
            thread.Join();

        }

        private static void PrintThreadContext()
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            
            Console.WriteLine($"DateTimeFormat {culture.DateTimeFormat.FullDateTimePattern}");
            Console.WriteLine($"Thread is bacground {Thread.CurrentThread.IsBackground}");
            Console.WriteLine($"Thread is ThreadPool {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Thread state: {Thread.CurrentThread.ThreadState}");
        }
    }
}