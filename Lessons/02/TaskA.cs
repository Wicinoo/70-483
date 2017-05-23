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
            var task = Task.Run(() => {
                Console.WriteLine("I am a task");

                return 95;
            });

            Console.WriteLine(task.Result);
            Console.WriteLine(task.ToString());
            Console.WriteLine(task.Status);
            task.Wait();
            Console.WriteLine(task.Status);
        }
    }
}