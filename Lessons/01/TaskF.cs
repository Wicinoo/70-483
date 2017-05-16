using System;

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
        private System.Timers.Timer _timer;
        private Random _random;

        public event EventHandler<MarketUpdatedEventArgs> MarketUpdated = delegate { };

        public TaskF()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Start();
            _timer.Elapsed += TimerElapsed;
            _random = new Random(DateTime.Now.Millisecond);
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            OnMarketUpdated(new MarketUpdatedEventArgs(new Decimal(_random.NextDouble()) * 60 + 20));
        }

        protected virtual void OnMarketUpdated(MarketUpdatedEventArgs e)
        {
            Console.WriteLine("Market running ...");
            MarketUpdated(this, e);
        }

        public static void Run()
        {
            TaskF taskF = new TaskF();
            taskF.MarketUpdated += WriteMarketValue;
            Console.ReadKey();
            taskF.MarketUpdated -= WriteMarketValue;
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        public static void WriteMarketValue(object sender, MarketUpdatedEventArgs e)
        {
            Console.WriteLine($"Current market value: {e.CurrentMarketValue}");
        }
    }

    public class MarketUpdatedEventArgs : EventArgs
    {
        public MarketUpdatedEventArgs() { }

        public MarketUpdatedEventArgs(decimal currentMarketValue)
        {
            CurrentMarketValue = currentMarketValue;
        }

        public decimal CurrentMarketValue { get; set; }
    }
}