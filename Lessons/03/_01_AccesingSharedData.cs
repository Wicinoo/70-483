using System;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _01_AccesingSharedData
    {
        public static void Run()
        {
            const int NumberOfIterations = 100000000;

            int value = 0;

            var incrementingTask = Task.Run(() =>
            {
                for (int i = 0; i < NumberOfIterations; i++) { value++; }
            });
            for (int i = 0; i < NumberOfIterations; i++) { value--; }

            incrementingTask.Wait();

            Console.WriteLine(value);
        }
    }
}