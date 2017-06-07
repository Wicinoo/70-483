using System;
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
            Market market = new Market() { Interval = 1000 };
            market.OnMarketUpdated += actionrnd;
            market.Start();
            Console.ReadKey();
            market.OnMarketUpdated -= actionrnd;
            Console.WriteLine("Market doesn't ganerate values now.");
            Console.ReadKey();
            market.Stop();
            Console.WriteLine("Market is now stopped.");
        }

        public static void actionrnd(decimal d)
        { Console.WriteLine("Market value is {0}", d); }
    }

    public class Market : Timer
    {
        public event Action<decimal> OnMarketUpdated;

        private static readonly Random getrandom = new Random();

       public Market()
        {
            this.Elapsed += Raise;
        }

        public void Raise(object source, ElapsedEventArgs e)
        {
            if (OnMarketUpdated != null)
            {
                OnMarketUpdated(getrandom.Next(20,80));
            }
        }
    }
}