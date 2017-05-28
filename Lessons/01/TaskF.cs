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
            market.OnMarketUpdate += Market_OnMarketUpdate;

            market.Start();

            Console.ReadKey();
            market.OnMarketUpdate -= Market_OnMarketUpdate;

            Console.ReadKey();
            market.Stop();
        }

        private static void Market_OnMarketUpdate(object sender, MarketUpdateArgs e)
        {
            Console.WriteLine($"Current market value: {e.MarketValue}");
        }
    }

    public class Market
    {
        public delegate void MarketUpdate(object sender, MarketUpdateArgs args);

        public event MarketUpdate OnMarketUpdate;

        private Timer timer;

        public Market()
        {
            timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RaiseMarketUpdate();
        }

        private void RaiseMarketUpdate()
        {
            MarketUpdate handler = OnMarketUpdate;
            if (handler != null)
            {
                OnMarketUpdate(this, GetValue());
            }
        }

        private MarketUpdateArgs GetValue()
        {
            var randomiser = new Random();
            return new MarketUpdateArgs() { MarketValue = randomiser.Next(20, 81) };
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }

    public class MarketUpdateArgs : EventArgs
    {
        public decimal MarketValue { get; set; }
    }
}