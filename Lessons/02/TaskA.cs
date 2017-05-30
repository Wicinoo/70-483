using System;

namespace Lessons._02
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.Write(i);
                }
                Console.WriteLine();

                Thread thread = Thread.CurrentThread;
                Console.WriteLine(thread.IsAlive);
                Console.WriteLine(thread.IsBackground);
                Console.WriteLine(thread.Name);
                Console.WriteLine(thread.Priority);
                Console.WriteLine(thread.IsThreadPoolThread);
                Console.WriteLine(thread.ThreadState);
            });
        }
    }
}