using System;
using System.Security.Permissions;
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
            try
            {
                throw new InvalidOperationException("Unhandled exception on the main thread.");
            }
            catch (Exception)
            {
                Console.WriteLine("handled exception in Run1");

            }

        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Run2()
        {
            // Implement global exception handling for all threads here ...

            AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);


            Application.ThreadException += new ThreadExceptionEventHandler(MyHandler);

            try
            {
                Task.Run(() =>
                {
                    throw new InvalidOperationException("Unhandled exception on a task.");
                }).Wait();
            }
            catch (AggregateException)
            {
                Console.WriteLine("handled exception in Run2");
            }

        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}