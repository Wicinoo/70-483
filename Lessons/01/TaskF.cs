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
            Console.WriteLine("TaskE:");
            Console.WriteLine("---------------------------------------");
            Market m = new Market();
            m.OnMarketUpdated += m_OnMarketUpdated;
            Timer t = new Timer();
            t.Interval = 2000;
            t.Elapsed += (sender, e) => { m.UpdateMarketValue(); };
            t.Start();
            Console.ReadKey();
            m.OnMarketUpdated -= m_OnMarketUpdated;
            Console.ReadKey();
            t.Stop();
            Console.WriteLine("---------------------------------------");
        }

        static void m_OnMarketUpdated(object sender, MarketEventArgs e)
        {
            Console.WriteLine("Market value: " + e.MarketValue);
        }
    }

    public class Market
    {
        public event EventHandler<MarketEventArgs> OnMarketUpdated = delegate { };

        public void UpdateMarketValue()
        {
            OnMarketUpdated(this, new MarketEventArgs() { MarketValue = new Random(DateTime.Now.Millisecond).Next(20, 80) });
        }

    }

    public class MarketEventArgs : EventArgs
    {
        public int MarketValue { get; set; } 
    }
}
