using System;
using System.Reflection;
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
            Task task = Task.Run((() =>
            {
                var contextArray = Thread.CurrentThread.GetType().GetProperties();

                foreach (PropertyInfo info in contextArray)
                {
                    Console.WriteLine($"{info}:{info.GetValue(Thread.CurrentThread, null)}");
                }
            }));

            task.Wait();
        }
    }
}