using System;
using System.Threading;
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
        
        public static void Run2()
        {

            // Implement global exception handling for all threads here ...
            Task.Run(() =>
            {
                Thread.GetDomain().UnhandledException += CurrentDomain_UnhandledException;

                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

         static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Notified of a thread exception... application is terminating.");
            
        }

    }
}