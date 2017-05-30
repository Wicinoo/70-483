using System;
using System.Threading.Tasks;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var task = new Task(
                () =>
                {
                    foreach (var item in Thread.CurrentContext.ContextProperties)
                    {
                        Console.WriteLine($"{item.Name} {item}");
                    }

                }
             );

            task.Start();
            task.Wait();
        }
    }
}