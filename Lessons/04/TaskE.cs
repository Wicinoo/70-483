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
            // Implement global exception handling here ...
            AppDomain.CurrentDomain.UnhandledException += MyGlobalExceptionHandler;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }
        
        public static void Run2()
        {
            // Implement global exception handling for all threads here ...
            AppDomain.CurrentDomain.UnhandledException += MyGlobalExceptionHandler;

            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

        public static void MyGlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Console.WriteLine($"{args.ExceptionObject}");
            Environment.Exit(1);
        }
    }
}