using System;
using System.Threading;

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
        delegate void SimpleDelegate();
        public static void Run()
        {
            MarketUpdater mu = new MarketUpdater();

            mu.OnMarketUpdated += MarketUpdated;
            SimpleDelegate asyncInvoker = () => { mu.Run(); };
            asyncInvoker.BeginInvoke(null, null);

            Console.ReadKey();

            mu.OnMarketUpdated -= MarketUpdated;

            //not needed since there already is one in Program.cs
            //Console.ReadKey();
        }

        public static void MarketUpdated(object sender, int marketValue)
        {
            Console.WriteLine(marketValue);
        }
    }

    public class MarketUpdater
    {
        public event EventHandler<int> OnMarketUpdated = delegate { };

        public void Run()
        {
            Random rnd = new Random();

            while (!Console.KeyAvailable)
            {
                this.OnMarketUpdated(this, rnd.Next(20, 80));
                Thread.Sleep(1000);
            }
        }
    }
}