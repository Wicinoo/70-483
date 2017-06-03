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
                var thread = Thread.CurrentThread;

                Console.WriteLine($"CurrentCulture: {thread.CurrentCulture}");

                Console.WriteLine($"IsAlive: {thread.IsAlive}");

                Console.WriteLine($"IsBackground: {thread.IsBackground}");

                Console.WriteLine($"IsThreadPoolThread: {thread.IsThreadPoolThread}");

                Console.WriteLine($"ManagedThreadId: {thread.ManagedThreadId}");

                Console.WriteLine($"Name: {thread.Name}");

                Console.WriteLine($"Priority: {thread.Priority}");

                Console.WriteLine($"ThreadState: {thread.ThreadState}");
            });

            task.Start();
        }
    }
}