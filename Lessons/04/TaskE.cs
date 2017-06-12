using System;
using System.Runtime.ExceptionServices;
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
            catch (Exception ex)
            {
                Print(ex.Message);
                throw;
            }
        
        }

        private static void Print(string value)
        {
            Console.WriteLine(value);
        }

        public static void Run2()
        {
            // Implement global exception handling for all threads here ...
            ExceptionDispatchInfo posibleException = null;
            Task.Run(() =>
            {
                try
                {
                    throw new InvalidOperationException("Unhandled exception on a task.");
                }
                catch (Exception ex)
                {
                    posibleException = ExceptionDispatchInfo.Capture(ex);
                }
            })
            .Wait();

            if (posibleException != null)
            {
                Print(posibleException.SourceException.Message);
                posibleException.Throw();
            }
        }
    }
}