using System;
using System.Threading;

namespace Lessons._02
{
    public static class _05_ThreadLocalExample
    {
        private static ThreadLocal<int> _field = 
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        public static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();
        }
    }
}