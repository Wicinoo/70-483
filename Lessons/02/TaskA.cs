using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        private static object _lockObject = new object();

        public static void Run()
        {
            Task t = Task.Run(() => { PrintThreadInfo("Task thread"); });
            t.ContinueWith((x) => { PrintThreadInfo("Task thread continue with"); });
            PrintThreadInfo("Main thread");
            t.Wait();
        }

        private static void PrintThreadInfo(string message)
        {
            lock (_lockObject)
            {
                var ct = Thread.CurrentThread;
                Console.WriteLine($"ThreadId: {ct.ManagedThreadId.ToString()}, message: {message}");
                Console.WriteLine($"Culture: {ct.CurrentCulture.Name}");
                Console.WriteLine($"UI Culture: {ct.CurrentUICulture.Name}");
                Console.WriteLine($"IsBackground: {ct.IsBackground.ToString()}");
                Console.WriteLine($"IsThreadPoolThread: {ct.IsThreadPoolThread.ToString()}");
                Console.WriteLine($"IsAlive: {ct.IsAlive.ToString()}");
            }
        }
    }
}