using System;
using System.Security.Permissions;
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
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Run1()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += GlobalExceptionHandler;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }
        
        public static void Run2()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += GlobalExceptionHandler;

            Task.Run(() =>
            {
                throw new ArithmeticException("Unhandled arithmetic exception on a task.");
            })
            .Wait();
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            Exception exception = (Exception) unhandledExceptionEventArgs.ExceptionObject;
            Console.WriteLine("Global Handler Caught : " + exception.Message);
        }
    }
}