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
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        public static void Run2()
        {
            // Implement global exception handling for all threads here ...
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Task.Run(() =>
            {
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Global exception handler caught : " + e.Message);
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}