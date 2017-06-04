using System;
using System.Threading;

namespace Lessons._02
{
    public static class _02_BackgroundThread 
    {
        public static void Run()
        {
            Thread thread = new Thread(new ThreadStart(DoOnOtherThread));
            thread.IsBackground = true; //this doesnt appear to work as per the book
            thread.Start();
        }

        private static void DoOnOtherThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Other thread: {0}", i);
                Thread.Sleep(100);
            }
        }
    }
}