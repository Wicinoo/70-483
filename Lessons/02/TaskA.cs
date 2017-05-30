using System;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            Task t = Task.Run(()=>
            {
                Console.WriteLine(Thread.CurrentThread.ExecutionContext.ToString());
            });
            
            t.Wait();
        }
    }
}
