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
                Console.WriteLine("Context 1: {0}", Thread.CurrentContext.ContextID);
                Console.WriteLine("Thread 1: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread state 1: {0}", Thread.CurrentThread.ThreadState);
                Console.WriteLine("Priority 1: {0}", Thread.CurrentThread.Priority);
                Console.WriteLine("Name 1: {0}", Thread.CurrentThread.Name);
                Console.WriteLine("IsAlive 1: {0}", Thread.CurrentThread.IsAlive);
                Console.WriteLine("IsBackground 1: {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("CurrentCulture 1: {0}", Thread.CurrentThread.CurrentCulture);
            });

            t.Wait();

            //var t2 = Task.Run(() =>
            //{
            //    Console.WriteLine("Context 2: {0}", Thread.CurrentContext.ContextID);
            //    Console.WriteLine("Thread 2: {0}", Thread.CurrentThread.ManagedThreadId);
            //    Console.WriteLine("Thread state 2: {0}", Thread.CurrentThread.ThreadState);
            //    Console.WriteLine("Priority 2: {0}", Thread.CurrentThread.Priority);
            //    Console.WriteLine("Name 2: {0}", Thread.CurrentThread.Name);
            //    Console.WriteLine("IsAlive 2: {0}", Thread.CurrentThread.IsAlive);
            //    Console.WriteLine("IsBackground 2: {0}", Thread.CurrentThread.IsBackground);
            //    Console.WriteLine("CurrentCulture 2: {0}", Thread.CurrentThread.CurrentCulture);
            //});

            //t2.Wait();
        }
    }
}
