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
                Console.WriteLine("Task.CurrentId {0}", Task.CurrentId);

                foreach (var contextProperty in Thread.CurrentContext.ContextProperties)
                {
                    Console.WriteLine("contextProperty {0} : {1}", contextProperty.Name, contextProperty.ToString());
                }

                Console.WriteLine("Thread.CurrentThread.CurrentCulture : {0}", Thread.CurrentThread.CurrentCulture);
                Console.WriteLine("Thread.CurrentThread.CurrentUICulture : {0}", Thread.CurrentThread.CurrentUICulture);
                Console.WriteLine("Thread.CurrentThread.ExecutionContext : {0}", Thread.CurrentThread.ExecutionContext);
                Console.WriteLine("Thread.CurrentThread.IsAlive : {0}", Thread.CurrentThread.IsAlive);
                Console.WriteLine("Thread.CurrentThread.IsBackground : {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("Thread.CurrentThread.IsThreadPoolThread : {0}", Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine("Thread.CurrentThread.ManagedThreadId : {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread.CurrentThread.Name : {0}", Thread.CurrentThread.Name);
                Console.WriteLine("Thread.CurrentThread.Priority : {0}", Thread.CurrentThread.Priority);
                Console.WriteLine("Thread.CurrentThread.ThreadState : {0}", Thread.CurrentThread.ThreadState);

                Console.WriteLine();
            });

            task.Wait();
        }
    }
}