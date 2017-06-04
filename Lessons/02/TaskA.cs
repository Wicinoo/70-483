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
            ExecutionContext ec; // = new ExecutionContext();
            Task<int> testTask = Task.Run(
                () =>
                    {
                        var foo = Thread.CurrentThread.ExecutionContext;
                        //ec = ExecutionContext.Capture();
                        //Console.WriteLine(ec.GetType());
                        //ec.GetType();
                        return 42;
                    });
            Console.WriteLine(testTask.Result); //returns..42
            Console.WriteLine(Thread.CurrentThread.ExecutionContext);
            //Console.WriteLine(ec.ToString());
        }
    }
}