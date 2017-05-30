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

            var thread1 = new Thread(() => { Console.WriteLine("Hi"); });
            var thread2 = new Thread(new ThreadStart(() => { Console.WriteLine("Hi"); }));
            var thread3 = new Thread(new ParameterizedThreadStart((data) => { Console.WriteLine("Hi"); }));

            thread3.Start(5);

            // Sleep, Join

            var stopThread = false;

            var t1 = new Thread(() =>
            {
                Console.WriteLine("T1");
                try
                {
                    while(!stopThread) { }
                    Console.WriteLine("Thread stopped");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });

            t1.Start();
            //t1.IsBackground = true;

            Console.WriteLine("TN1");
            Console.WriteLine("TN2");

            // Foreground / background threads
            // Terminating a thread

            //t1.Abort();
            stopThread = true;

            // [ThreadStatic]

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _threadSafeField++;
                    Console.WriteLine(_threadSafeField);
                }
            }).Start();
            
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _threadSafeField++;
                    Console.WriteLine(_threadSafeField);
                }
            }).Start();

            // Thread execution context
            // Thread pool
            ThreadPool.QueueUserWorkItem(s => { });
            var maxWorkerThreads = 0;
            var completionPortThreads = 0;

            ThreadPool.GetMaxThreads(out maxWorkerThreads, out completionPortThreads);
            Console.WriteLine(maxWorkerThreads);

            // Tasks, task scheduler, waiting for a task

            new Task(() => { }).Start();
            Task.Run(() => { });
            var task1 = Task.Run(() => 1);

            Console.WriteLine(task1.Result);

            task1.Wait();
            Task.WaitAll(Task.Run(() => { }), Task.Run(() => {}));
            Task.WaitAny(Task.Run(() => { }), Task.Run(() => {}));

            // Continuation tasks
            
            var mainTask = Task.Run(() => 42);
            mainTask.ContinueWith(result => Console.WriteLine(result.Result));
            mainTask.ContinueWith(_ => Console.WriteLine("Cancelled"),
                TaskContinuationOptions.OnlyOnCanceled);

            // TaskFactory

            //var tf = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.OnlyOnCanceled);
            //tf.StartNew(() => { });

            // Parallel class, ParallelLoopState, Break, Stop

            Parallel.For(0, 5, (i, loopState) => { if (loopState.IsStopped) { Console.WriteLine(1);} });

            // async, await

            // 1. Waiting for an I/O operation
            // 2. Processing the result of 1
            // 3. Processing independent on 1 and 2

            Task.Run(() =>
            {
                // 1. Waiting for an I/O operation
            }).ContinueWith(task => {/* 2. Processing the result of 1 */});
            
            // 3. Processing independent on 1 and 2

            var r = GetContentAsync("http://google.com");                // 1
            Console.WriteLine("Some other processing");                  // 3
            Console.WriteLine("Length of result: {0}", r.Result.Length); // 2

            // CPU-bound task vs. I/O-bound task

            // CPUB task uses a thread during its whole processing.
            // IOB task releases the thread until the result of the IO operation.

            // Managing threads in WPF and ASP.NET application.

            // PLINQ

            // IEnumerable.AsParallel()

            var numbers = Enumerable.Range(0, 10);
            var array = numbers
                .AsParallel()
                //.AsOrdered()
                .Where(n => n < 50)
                .Select(n => { Console.WriteLine(n); return n; })
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithDegreeOfParallelism(5);

            Console.WriteLine("foreach:");

            foreach (var n in array)
            {
                Console.WriteLine(n);
            }

            // ParallelQuery.ForAll()

            Console.WriteLine("ForAll:");

            array.ForAll(Console.WriteLine);

            // Concurrent collections

            //BlockingCollection<T>
            //ConcurrentBag<T>
            //ConcurrentDictionary<T>
            //ConcurrentQueue<T>
            //ConcurrentStack<T>
        }

        private static async Task<string> GetContentAsync(string uri)
        {
            return await new HttpClient().GetStringAsync(uri);
        }
    }
}