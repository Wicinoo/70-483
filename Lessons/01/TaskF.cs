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
        private static System.Timers.Timer _timer;
        private static MarketUpdateEvent marketUpdateEvent = new MarketUpdateEvent();

        public static void Run()
        {
            var r = new Random();
            marketUpdateEvent.OnMarketUpdated += (sender, e) => Console.WriteLine(r.Next(20, 80));
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            Console.ReadKey();
            _timer.Elapsed -= _timer_Elapsed;
            Console.ReadKey();
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            marketUpdateEvent.Raise();
        }
    }

    public class MarketUpdateEvent
    {
        public event EventHandler OnMarketUpdated = delegate { };

        public void Raise()
        {
            OnMarketUpdated(this, EventArgs.Empty);
        }
    }


}