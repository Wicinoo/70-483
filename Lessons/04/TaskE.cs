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
    public static class TaskE
    {
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Run1()
        {
            // Implement global exception handling here ...
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((sender, e) => { Console.WriteLine("Handling uncaught exception + " + e.ToString()); });

            throw new InvalidOperationException("Unhandled exception on the main thread.");
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Run2()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((sender, e) => { Console.WriteLine("Handling uncaught exception + " + e.ToString()); });

            try
            {
                Task.Run(() =>
                {
                    throw new InvalidOperationException("Unhandled exception on a task.");
                })
                   .ContinueWith(t => { throw t.Exception; }, TaskScheduler.FromCurrentSynchronizationContext()).Wait();
            }
            catch (AggregateException e)
            {
                e.Flatten();
            }


        }
    }
}