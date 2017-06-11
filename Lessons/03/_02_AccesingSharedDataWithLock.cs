using System;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _02_AccesingSharedDataWithLock
    {
        public static void Run()
        {
            const int NumberOfIterations = 1000000;

            int value = 0;

            var @lock = new object();

            var incrementingTask = Task.Run(() =>
            {
                for (int i = 0; i < NumberOfIterations; i++)
                {
                    lock (@lock)
                    {
                        value++;
                    }
                }
            });

            for (int i = 0; i < NumberOfIterations; i++)
            {
                lock (@lock)
                {
                    value--;
                }
            }

            incrementingTask.Wait();

            Console.WriteLine(value);
        }
    }
}