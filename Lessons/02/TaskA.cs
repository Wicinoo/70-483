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
                var context = Thread.CurrentThread;
                Console.WriteLine(context.CurrentCulture);
                Console.WriteLine(context.Priority);
                Console.WriteLine(context.IsBackground);
            });
            task.Wait();
        }
    }
}