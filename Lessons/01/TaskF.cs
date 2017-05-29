using System;
using System.Runtime.InteropServices.ComTypes;
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
        public static void Run()
        {
            var marketScanner = new MarketScanner();
            marketScanner.MarketUpdated += PrintInputEvent;

            marketScanner.Start();
            marketScanner.MarketUpdated -= PrintInputEvent;
            marketScanner.Start();           
            Console.ReadKey();
        }

        private static void PrintInputEvent(object o, OnMarketUpdatedArgs args)
        {
            Console.WriteLine(args.MarketPrice);
        }
    }

    delegate void OnMarketUpdated(object sender, OnMarketUpdatedArgs args);

    class MarketScanner
    {      
        public event OnMarketUpdated MarketUpdated;

        private bool _running;

        private Random _random;

        public void Update(decimal price)
        {
            MarketUpdated?.Invoke(this, new OnMarketUpdatedArgs() { MarketPrice = price });
        }

        public void Start()
        {
            _running = true;
            _random = new Random();
            Run();
        }

        public void Yield()
        {
            _running = false;
        }

        public void Run()
        {
            while (_running)
            {
                Update(Convert.ToDecimal(_random.NextDouble() * 60) + 20);

                Thread.Sleep(1000);

                if (Console.KeyAvailable)
                {
                    Yield();
                }
            }
        }
    }

    public class OnMarketUpdatedArgs : EventArgs
    {
        public decimal MarketPrice { get; set; }
    }
}