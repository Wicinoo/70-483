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
            var t = Task.Run(() =>
            {
                Console.WriteLine("Current Culture : {0}", Thread.CurrentThread.CurrentCulture);
                Console.WriteLine("Is Alive : {0}", Thread.CurrentThread.IsAlive);
                Console.WriteLine("Id IsBackground : {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("ThreadState : {0}", Thread.CurrentThread.ThreadState);
            });

            t.Wait();
        }
    }
}