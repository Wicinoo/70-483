using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _07_TaskWaitAny
    {
        public static void Run()
        {
            Task longRunningTask = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });

            int index = Task.WaitAny(new [] { longRunningTask }, 1000);

            if (index == -1)
                Console.WriteLine("Task timed out");
        }
    }
}