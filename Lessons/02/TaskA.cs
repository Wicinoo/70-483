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
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {

                    Console.Write('*');
                }
            });

            //Console.WriteLine(t.Status);
            //Console.WriteLine(t.GetType());
            //ExecutionContext ec = ExecutionContext.Capture();
            //Console.WriteLine(ec.ToString());
            //Console.WriteLine(Thread.CurrentThread.ThreadState);
            //Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(Thread.CurrentThread.ExecutionContext);
            t.Wait();
        }
    }
}
