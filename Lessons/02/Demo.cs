using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    public class Demo
    {
        [ThreadStatic]
        private static int _threadSafeField;

        public static void Run()
        {
            // Process vs. Thread
            // Virtual memory, context switching, parallelism
            // Creating a new thread
            // Sleep, Join
            // Foreground / background threads
            // Terminating a thread
            // [ThreadStatic]
            // Thread execution context
            // Thread pool
            // Tasks, task scheduler, waiting for a task
            // Continuation tasks
            // TaskFactory
            // Parallel class, ParallelLoopState, Break, Stop
            // async, await
            // CPU-bound task vs. I/O-bound task
            // CPUB task uses a thread during its whole processing.
            // IOB task releases the thread until the result of the IO operation.
            // Managing threads in WPF and ASP.NET application.
            // PLINQ
            // IEnumerable.AsParallel()
            // ParallelQuery.ForAll()
        }
    }
}