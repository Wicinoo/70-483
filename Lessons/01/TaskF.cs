using System;
using System.Dynamic;
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
        private delegate void OnMarketUpdated(object sender, MarketEventArgs e);

        public static void Run()
        {
            var marketUpdater = new MarketUpdater();
            marketUpdater.MarketUpdated += onMarketUpdated_WriteToConsole;

            marketUpdater.Start();
            Console.ReadKey();
            marketUpdater.MarketUpdated -= onMarketUpdated_WriteToConsole;
            Console.ReadKey();
            marketUpdater.Stop();

            Console.WriteLine("Market updater stopped!");
        }

        private static void onMarketUpdated_WriteToConsole(object sender, MarketEventArgs e)
        {
            Console.WriteLine(e.MarketPrice);
        }

        private class MarketUpdater
        {
            public event OnMarketUpdated MarketUpdated;

            private Thread _thread;

            public void Start()
            {
                _thread = new Thread(RaiseUpdate);
                _thread.Start();
            }

            public void Stop()
            {
                _thread.Abort();
            }

            private void RaiseUpdate()
            {
                var generator = new Random();

                while (true)
                {
                    var marketPrice = generator.Next(20, 80);
                    MarketUpdated?.Invoke(this, new MarketEventArgs(marketPrice));
                    Thread.Sleep(1000);
                }
            }
        }

        private class MarketEventArgs : EventArgs
        {
            public readonly int MarketPrice;

            public MarketEventArgs(int marketPrice)
            {
                MarketPrice = marketPrice;
            }
        }
    }
}