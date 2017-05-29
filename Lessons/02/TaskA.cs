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
                Console.WriteLine($"ApartmentState: {Thread.CurrentThread.GetApartmentState()}");
                Console.WriteLine($"CurrentCulture: {Thread.CurrentThread.CurrentCulture}");
                Console.WriteLine($"CurrentUICulture: {Thread.CurrentThread.CurrentUICulture}");
                Console.WriteLine($"IsAlive: {Thread.CurrentThread.IsAlive}");
                Console.WriteLine($"IsBackground: {Thread.CurrentThread.IsBackground}");
                Console.WriteLine($"IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
                Console.WriteLine($"ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Priority: {Thread.CurrentThread.Priority}");
                Console.WriteLine($"ThreadState: {Thread.CurrentThread.ThreadState}");
            });
        }
    }
}