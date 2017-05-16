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
        public static void Run()
        {
            var marketUpdater = new MarketUpdater();

            marketUpdater.OnMarketUpdated += OnMarketUpdaterOnOnMarketUpdated;

            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    marketUpdater.Update();
                    Thread.Sleep(1000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            marketUpdater.OnMarketUpdated -= OnMarketUpdaterOnOnMarketUpdated;

            Console.ReadKey(true);
        }

        private static void OnMarketUpdaterOnOnMarketUpdated()
        {
            Console.WriteLine("Market Updated");
        }
    }

    public class MarketUpdater
    {
        public event Action OnMarketUpdated;

        public void Update()
        {
            Console.WriteLine("Doing Stuff");

            if (OnMarketUpdated != null)
            {
                OnMarketUpdated();
            }
        }
    }
}