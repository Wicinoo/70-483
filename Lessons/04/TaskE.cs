using System;
using System.Threading.Tasks;

namespace Lessons._04
{
    /// <summary>
    /// Use global exception handlers to catch unhandled exceptions 
    /// and print them out in the console.
    /// Processing should not continue after handling.
    /// </summary>
    public class TaskE
    {
        public static void Run1()
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }
        
        public static void Run2()
        {
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;

            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

        public static void ExceptionHandler(object sender, UnhandledExceptionEventArgs arg)
        {
            Console.WriteLine(arg.ExceptionObject);
            Environment.Exit(1);
        }
    }
}