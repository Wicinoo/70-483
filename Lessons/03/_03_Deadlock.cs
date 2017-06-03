using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    public static class _03_Deadlock
    {
        public static void Run()
        {
            var lockA = new object();
            var lockB = new object();

            var task1 = Task.Run(() =>
            {
                lock (lockA)
                {
                    Console.WriteLine("Task1 used lockA.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Task1 is waiting for lockB ...");
                    lock (lockB)
                    {
                        Console.WriteLine("Task1 got lockB.");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (lockB)
                {
                    Console.WriteLine("Task2 used lockB.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Task2 is waiting for lockA ...");
                    lock (lockA)
                    {
                        Console.WriteLine("Task2 got lockA.");
                    }
                }

            });

            task1.Wait();
        }
    }
}