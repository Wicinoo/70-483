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
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }
        
        public static void Run2()
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ee = (Exception)e.ExceptionObject;
            Console.WriteLine(ee.Message + (ee.InnerException == null ? string.Empty : ": " + ee.InnerException.Message));
            Environment.Exit(1);
        }
    }
}
