using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _04_UsingInterlocked
    {
        public static void Run()
        {
            const int NumberOfIterations = 1000000;

            int value = 0;

            var incrementingTask = Task.Run(() =>
            {
                for (int i = 0; i < NumberOfIterations; i++)
                    Interlocked.Increment(ref value);
            });

            for (int i = 0; i < NumberOfIterations; i++)
                Interlocked.Decrement(ref value);

            incrementingTask.Wait();

            Console.WriteLine(value);
        }
    }
}