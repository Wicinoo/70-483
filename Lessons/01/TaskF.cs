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
            market.MarketUpdated += OnMarketUpdated; 
            market.Init();

            Console.ReadKey();
            market.MarketUpdated -= OnMarketUpdated;
        }

        public static void OnMarketUpdated(object obj, MarketEventArgs args)
        {
            Console.WriteLine(args.MarketValue);
        }
    }

    public class MarketEventArgs : EventArgs
    {
        public int MarketValue { get; set; }
    }

    public class Market
    {
        //public delegate void MarketUpdatedEventHandler(object source, MarketEventArgs args);
        //public event MarketUpdatedEventHandler MarketUpdated;

        public event EventHandler<MarketEventArgs> MarketUpdated; 

        private readonly Func<int> _getMarketValue = () => new Random().Next(20, 80);

        private Timer _timer;

        public void Init()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Tick;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void Tick(object source, ElapsedEventArgs args)
        {
            OnMarketUpdated(_getMarketValue());
        }

        protected virtual void OnMarketUpdated(int value)
        {
            if (MarketUpdated != null)
            {
                MarketUpdated(this, new MarketEventArgs() { MarketValue = value} );
            }
        }
    }
}