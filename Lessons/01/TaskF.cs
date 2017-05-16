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
            var market = new Market();

            market.OnMarketUpdated += Market_OnMarketUpdated;
            Console.ReadKey();
            market.OnMarketUpdated -= Market_OnMarketUpdated;
        }

        static void Market_OnMarketUpdated(decimal value)
        {
            Console.WriteLine(value);
        }
    }

    class Market
    {
        public event Action<decimal> OnMarketUpdated;

        private readonly Timer _timer;
        private readonly Random _random;

        public Market()
        {
            _random = new Random();

            _timer = new Timer()
            {
                Interval = 1000
            };
            _timer.Start();

            _timer.Elapsed += Timer_Elapsed;
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnMarketUpdated?.Invoke(_random.Next(20, 80));
        }
    }
}