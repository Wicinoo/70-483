using System;
using System.Linq;
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
            Task.Run( () =>
            {
                    Console.WriteLine(Thread.CurrentContext);
            });
        }
    }
}