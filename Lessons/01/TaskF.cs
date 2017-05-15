using System;
using System.Threading;
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
        static readonly Random Generator = new Random();

        public static void Run()
        {
            Func<decimal> marketPrice = () => Convert.ToDecimal(Generator.NextDouble() * 60 + 20);

            MarketScanner scanner = new MarketScanner { OnMarketUpdated = Console.WriteLine };

            while (true)
            {
                long start = DateTime.Now.Ticks;

                scanner.Update(marketPrice());

                if (Console.KeyAvailable)
                {
                    break;
                }

                int elapsedInMilliseconds = (int) ((DateTime.Now.Ticks - start) / 10000);
                int wait = 1000 - elapsedInMilliseconds;

                Thread.Sleep(wait <= 0 ? 1 : wait);
            }

            Console.WriteLine("Stopped reading market pricing data.");
            Console.ReadKey();
        }
    }

    class MarketScanner
    {
        public Action<decimal> OnMarketUpdated { get; set; }

        public void Update(decimal price)
        {
            OnMarketUpdated?.Invoke(price);
        }
    }
}