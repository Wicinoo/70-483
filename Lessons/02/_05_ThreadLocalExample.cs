using System;
using System.Threading;

namespace Lessons._02
{
    public static class _05_ThreadLocalExample
    {
        //ThreadLocal provides thread-local storage of date
        private static ThreadLocal<int> _field = 
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        public static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Task5 Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Task5 Thread B: {0}", x);
                }
            }).Start();
        }
    }
}