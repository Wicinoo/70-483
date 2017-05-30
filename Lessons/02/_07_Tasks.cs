using System;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _07_Tasks
    {
        public static void Run()
        {
            Task task = Task.Run(() =>
            {
                for (int x = 0; x < 50; x++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            });

            Console.WriteLine("Outside the task");

            task.Wait();
        }
    }
}