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
            Task t = Task.Run(() =>
            {
                Console.WriteLine("ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("ContextId: {0}", Thread.CurrentContext.ContextID);
            });

            t.Wait();
        }
    }
}