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
            AppDomain.CurrentDomain.UnhandledException += ExceptionCatcher;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        private static void ExceptionCatcher(object sender, UnhandledExceptionEventArgs ueArgs)
        {
            var exception = ueArgs.ExceptionObject as Exception;
            var innerException = exception?.InnerException;

            Console.WriteLine(exception?.Message);
            Console.WriteLine(innerException?.Message);
            Console.ReadKey();
            Environment.Exit(1);
        }
        
        public static void Run2()
        {
            // Implement global exception handling for all threads here ...

            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }
    }
}