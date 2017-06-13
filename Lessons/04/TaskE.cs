using System;
using System.Net.Mime;
using System.Runtime.ExceptionServices;
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
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        private static void Print(string value)
        {
            Console.WriteLine(value);
        }

        public static void Run2()
        {
            // Implement global exception handling for all threads here ...
            //Application.ThreadException += UnhandledThreadExceptionCatcher

            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");

            })
            .Wait();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception) e.ExceptionObject;
            Print(ex.Message);
            Console.WriteLine("Runtime terminating: {0}", e.IsTerminating);
        }
    }
}