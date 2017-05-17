using System;
using System.IO;
using System.Timers;

namespace Lessons._01
{
    /// <summary>
    /// Implement a class that raises OnMarketUpdated event each second. 
    /// The event passes a decimal number that represents current market value.
    /// It can be a random number from 20 to 80.
    /// Register for the event from a class and print a message with the value to console.
    /// After you press a key, unregister from the event, but keep application live.
    /// After you press next key, stop the application.
    /// </summary>
    public class TaskF
    {
        public static void Run()
        {
            var timer = new Timer(1000);

            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Enabled = true;                      
            timer.Start();

            Console.ReadKey();

            timer.Elapsed -= new ElapsedEventHandler(timer_Tick);

            Console.ReadKey();
        }

        public static void timer_Tick(object sender, EventArgs e)
        {
            OnMarketUpdated onMarketUpdated = new OnMarketUpdated();
            onMarketUpdated.Raise(new Random().Next(20,81));
        }
        public class OnMarketUpdated
        {
            public event Action<decimal> OnEvent = (decimal number) => Console.WriteLine("Market value is {0}", number);

            public void Raise(decimal number)
            {
                if (OnEvent != null)
                {
                    OnEvent(number);
                }
            }
        }
    }
}