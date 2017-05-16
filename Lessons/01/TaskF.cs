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
            var market = new Market();

            market.OnMarketChange += PrintMarketValue;

            var marketThread = new Thread(() => market.Start());

            marketThread.Start();

            Console.ReadKey();

            Console.Out.WriteLine("Unregistering OnMarketChange event now.");

            market.OnMarketChange -= PrintMarketValue;

            Console.ReadKey();

            Console.Out.WriteLine("Closing market now.");

            market.Stop();
        }

        private static void PrintMarketValue(object sender, int i)
        {
            Console.Out.WriteLine($"The current market value is {i}.");
        }
    }

    public class Market
    {
        public event EventHandler<int> OnMarketChange = delegate { };

        private bool _shouldRun = true;

        public void Start()
        {
            var random = new Random();

            while (_shouldRun)
            {
                var marketValue = random.Next(20, 80);

                OnMarketChange(this, marketValue);

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public void Stop()
        {
            _shouldRun = false;
        }
    }
}