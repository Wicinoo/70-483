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
    public class TaskF {
        public event EventHandler<MarketArgs> OnMarketUpdated = delegate { };
        
        public void Run() {
            OnMarketUpdated += TaskF_OnMarketUpdated;

            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Timer_OnElapsed);
            timer.Interval = 1000;
            timer.Enabled = true;

            Console.ReadKey();
            OnMarketUpdated -= TaskF_OnMarketUpdated;
        }

        private void TaskF_OnMarketUpdated(object sender, MarketArgs e) {
            Console.WriteLine(e.Value);
        }

        private void ReadMarketData() {
            OnMarketUpdated(this, new MarketArgs { Value = new Random().Next(20, 80 + 1) });
        }

        private void Timer_OnElapsed(object sender, ElapsedEventArgs e) {
            ReadMarketData();
        }
    }

    public class MarketArgs : EventArgs {
        public decimal Value { get; set; }
    }
}