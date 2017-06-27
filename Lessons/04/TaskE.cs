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
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
            Console.ReadLine();
            Environment.Exit(1);
        }

        public static void Run2()
        {
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

            Task.Run(() =>
            {
                Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }
    }
}