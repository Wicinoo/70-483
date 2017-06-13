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
            try
            {
                throw new InvalidOperationException("Unhandled exception on the main thread.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            catch (AggregateException ex)
            {
                Console.WriteLine("There where {0} exceptions", ex.InnerExceptions.Count);

                if (ex.InnerExceptions.Count > 0)
                {
                    foreach (var innerException in ex.InnerExceptions)
                    {
                        Console.WriteLine("- {0}", innerException.Message);
                    }
                }
            }
        }
    }
}