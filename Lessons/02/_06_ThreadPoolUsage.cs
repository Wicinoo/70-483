using System;
using System.Threading;

namespace Lessons._02
{
    public static class _06_ThreadPoolUsage
    {
        public static void Run()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            int workerThreads;
            int completionPortThreads;

            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);

            Console.WriteLine("Worked threads: {0}, CompletionPortThreads: {1}", workerThreads, completionPortThreads);
        }
    }
}