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
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Exception caught.");
            TaskA.PrintExceptionDetails((Exception)e.ExceptionObject);
        }

        public static void Run2()
        {
            // Implement global exception handling for all threads here ...
            try
            {

                Task.Run(() =>
                {
                    throw new InvalidOperationException("Unhandled exception on a task.");
                })
                .Wait();
            }
            catch (AggregateException aex)
            {
                Console.WriteLine("Aggregate exception from task caught.");
                TaskA.PrintExceptionDetails(aex.InnerExceptions[0]);
                Environment.FailFast("Quitting.");
            }

            Console.WriteLine("Finished.");
        }
    }
}