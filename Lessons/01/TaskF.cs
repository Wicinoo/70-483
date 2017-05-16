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
            var marketValue = new MarketValue();
            var marketValuePrinter = new MarketValuePrinter();

            TimerCallback marketValueUpdate = marketValueState => marketValue.Raise();

            marketValue.OnMarketUpdated += (value) => marketValuePrinter.PrintMarketValue(value);

            using (var timer = new Timer(marketValueUpdate, marketValue, 0, 1000))
            {
                Console.Read();
                marketValue.OnMarketUpdated -= (value) => marketValuePrinter.PrintMarketValue(value);
            }
        }

        public class MarketValue
        {
            public event Action<decimal> OnMarketUpdated;

            public void Raise()
            {
                if (OnMarketUpdated != null)
                {
                    var randomNumber = new Random();

                    OnMarketUpdated(Convert.ToDecimal(randomNumber.Next(20, 80)));
                }
            }
        }

        public class MarketValuePrinter
        {
            public void PrintMarketValue(decimal marketValue)
            {
                Console.WriteLine($"Current market value is: {marketValue}");
            }
        }
    }
}