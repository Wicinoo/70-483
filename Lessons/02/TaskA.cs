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
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"Culture of the current thread: {Thread.CurrentThread.CurrentCulture}");
                Console.WriteLine($"Is background thread: {Thread.CurrentThread.IsBackground}");
                Console.WriteLine($"IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
                Console.WriteLine($"Current thread's priority: {Thread.CurrentThread.Priority}");
                Console.WriteLine($"Current thread's principal: {Thread.CurrentPrincipal.Identity.Name}");
            });
        }
    }
}