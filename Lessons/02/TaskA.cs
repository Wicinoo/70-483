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
            var t = Task.Run(() =>
            {
                Console.WriteLine("Context: {0}", Thread.CurrentContext.ContextID);
                Console.WriteLine("Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread state: {0}", Thread.CurrentThread.ThreadState);
            });

            t.Wait();
        }
    }
}