using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Channels;
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
            market.OnMarketUpdated += UpdateMarketValue();

            Console.ReadKey();
            market.OnMarketUpdated -= UpdateMarketValue();

            Console.ReadKey();

        }

        private static EventHandler UpdateMarketValue()
        {
            return (sender, e) => {Console.WriteLine(
                $"ActualMarketValue={((MarketEventArgs) e).MarketValue}");};
        }
    }

    public class MarketEventArgs : EventArgs
    {
        public decimal MarketValue { get; set; } 
    }

    public class Market
    {
        public event EventHandler OnMarketUpdated = delegate {};
        private readonly Random _randomProvider = new Random();
        private Timer _timer;
        public Market()
        {            
            _timer = new Timer();
            _timer.Elapsed   += this.timer_Tick;
            _timer.Interval = 1000;
            _timer.Start();   
        }

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateMarket();
        }
        private void RaiseEventForUpdateMarket(decimal marketvalue)
        {
            this.OnMarketUpdated(this, new MarketEventArgs() { MarketValue = marketvalue});
        }

        private void UpdateMarket()
        {
            RaiseEventForUpdateMarket(this.GetActualMarketValue());
        }


        private decimal GetActualMarketValue()
        {
            return _randomProvider.Next(20, 80);
        } 

    }
}