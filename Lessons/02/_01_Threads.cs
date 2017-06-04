using System;
using System.Threading;

namespace Lessons._02
{
    public static class _01_Threads 
    {
        public static void Run()
        {
            Thread thread = new Thread(new ThreadStart(DoOnOtherThread));
            thread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work");
                Thread.Sleep(0);
            }

            thread.Join();
        }

        private static void DoOnOtherThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Other thread: {0}", i);
                //foreach (var cp in Thread.CurrentContext.ContextProperties)
                //{
                //    Console.WriteLine(cp.Name);
                //}

                Thread.Sleep(0);
                //Console.WriteLine(Thread.CurrentContext.ContextProperties[0].ToString());
            }
        }
    }
}