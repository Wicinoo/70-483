using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;

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
                Console.WriteLine("Thread.CurrentThread.CurrentCulture" + "\t" + Thread.CurrentThread.CurrentCulture);
                Console.WriteLine("Thread.CurrentThread.CurrentUICulture" + "\t" + Thread.CurrentThread.CurrentUICulture);
                Console.WriteLine("Thread.CurrentThread.IsAlive" + "\t\t" + Thread.CurrentThread.IsAlive);
                Console.WriteLine("Thread.CurrentThread.IsBackground" + "\t" + Thread.CurrentThread.IsBackground);
                Console.WriteLine("Thread.CurrentThread.IsThreadPoolThread" + "\t" + Thread.CurrentThread.IsThreadPoolThread);

                Thread.Sleep(500);

                Console.WriteLine("Thread.CurrentThread.Name" + "\t" + Thread.CurrentThread.Name);
                Console.WriteLine("Thread.CurrentThread.Priority" + "\t\t" + Thread.CurrentThread.Priority);
                Console.WriteLine("Thread.CurrentThread.ManagedThreadId" + "\t" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread.CurrentThread.ThreadState" + "\t" + Thread.CurrentThread.ThreadState);
            });


            task.Wait();
            Console.WriteLine("doing something after task finished");
        }
    }
}