using System;
using System.Threading;

namespace Lessons._02
{
    public static class _04_ThreadStaticExample
    {
        // Switch off ThreadStatic to share _field between both threads.
        [ThreadStatic]
        private static int _field;

        public static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();
        }
    }
}
