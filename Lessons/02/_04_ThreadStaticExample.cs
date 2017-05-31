using System;
using System.Threading;

namespace Lessons._02
{
    public static class _04_ThreadStaticExample
    {
        // Switch off ThreadStatic to share _field between both threads.
        //[ThreadStatic] //Indicates that the value of a static field is unique for each thread.
        private static int _field;

        public static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Task4 Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Task4 Thread B: {0}", _field);
                }
            }).Start();
        }
    }
}
