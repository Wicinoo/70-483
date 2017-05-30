using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run() {
            Task task = Task.Run(() => {
                Console.WriteLine(Thread.CurrentThread.ToString());
                Console.WriteLine(Thread.CurrentThread.GetApartmentState());
                Console.WriteLine(Thread.CurrentThread.CurrentCulture);
                Console.WriteLine(Thread.CurrentThread.CurrentUICulture);
                Console.WriteLine(Thread.CurrentThread.ExecutionContext);
                Console.WriteLine(Thread.CurrentThread.IsAlive);
                Console.WriteLine(Thread.CurrentThread.IsBackground);
                Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(Thread.CurrentThread.Priority);
                Console.WriteLine(Thread.CurrentThread.ThreadState);
            });
        }
    }
}