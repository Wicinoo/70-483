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
        public static void Run()
        {
            var task = new Task(() =>
            {
                var currentThread = Thread.CurrentThread;

                Console.WriteLine($"Name: {currentThread.Name}");
                Console.WriteLine($"CurrentCulture: {currentThread.CurrentCulture}");
                Console.WriteLine($"CurrentUICulture: {currentThread.CurrentUICulture}");
                Console.WriteLine($"IsAlive: {currentThread.IsAlive}");
                Console.WriteLine($"IsBackground: {currentThread.IsBackground}");
                Console.WriteLine($"IsThreadPoolThread: {currentThread.IsThreadPoolThread}");
                Console.WriteLine($"ManagedThreadId: {currentThread.ManagedThreadId}");
                Console.WriteLine($"Priority: {currentThread.Priority}");
                Console.WriteLine($"ThreadState: {currentThread.ThreadState}");
            });
            
            task.Start();
        }
    }
}