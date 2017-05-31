using System;
using System.Threading;

namespace Lessons._02
{
    public static class _03_StoppingThread
    {
        public static void RunWithUsingSharedVariable()
        {
            var stopped = false;

            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            thread.Start();

            stopped = true;
            thread.Join();
        }

        public static void RunWithUsingAbort()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("Running...");
                Thread.Sleep(1000);
            }));

            thread.Start();

            // ThreadAbortException is thrown on the thread.
            thread.Abort();
        }
    }
}