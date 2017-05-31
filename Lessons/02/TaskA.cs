using System;
using System.ComponentModel;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            Thread threadStaticStart = new Thread(new ThreadStart(GetThreadStart));

            threadStaticStart.Start();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(threadStaticStart.CurrentCulture))
            {
                Console.WriteLine("{0} : {1}", property.Name, property.GetValue(threadStaticStart.CurrentCulture));
            }
        }

        private static void GetThreadStart()
        {
           // Console.WriteLine("There should be {0} static calls from this thread", 15);
            for (int i = 0; i < 15; i++)
            {
               // Console.WriteLine("Other static thread call: {0}", i);
                Thread.Sleep(500);
            }
        }

    }
}