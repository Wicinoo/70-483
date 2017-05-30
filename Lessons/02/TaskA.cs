using System;
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
            var task = Task.Run(() =>
            {
                Console.WriteLine(System.Threading.Thread.CurrentThread.CurrentCulture);
                Console.WriteLine(System.Threading.Thread.CurrentThread.CurrentUICulture);
                Console.WriteLine(System.Threading.Thread.CurrentThread.IsAlive);
                Console.WriteLine(System.Threading.Thread.CurrentThread.IsBackground);
                Console.WriteLine(System.Threading.Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(System.Threading.Thread.CurrentThread.Name);
                Console.WriteLine(System.Threading.Thread.CurrentThread.Priority);
                Console.WriteLine(System.Threading.Thread.CurrentThread.ThreadState);
            });
        }


    }
}