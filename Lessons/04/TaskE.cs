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
            AppDomain domain = AppDomain.CurrentDomain;
            domain.UnhandledException += ErrorLogger;

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        public static void Run2()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            domain.UnhandledException += ErrorLogger;

            Task.Run(() =>
            {
                domain.UnhandledException += ErrorLogger;
                throw new InvalidOperationException("Unhandled exception on a task.");
            })
            .Wait();
        }

        private static void ErrorLogger(object sender, UnhandledExceptionEventArgs args)
        {
            Console.WriteLine(((Exception)args.ExceptionObject).Message);
        }
    }
}