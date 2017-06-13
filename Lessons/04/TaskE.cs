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
            AppDomain.CurrentDomain.UnhandledException += MyHandler;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        public static void Run2()
        {
            // Implement global exception handling for all threads here ...
            AppDomain.CurrentDomain.UnhandledException += MyHandler;
            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

        public static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Console.WriteLine($"Exception caught : {args.ExceptionObject}");
            Console.WriteLine("Press Enter to continue");
            Environment.Exit(1);
        }
    }
}