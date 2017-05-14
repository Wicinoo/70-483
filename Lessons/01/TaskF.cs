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
        private delegate void MarketUpdate(decimal value);

        class MarketTimer
        {
            private Random _random = new Random();

            private bool _isStopped;

            public void Run()
            {
                do
                {
                    var value = GenerateValue();

                    OnMarketUpdate?.Invoke(value);

                    Thread.Sleep(1000);
                }
                while (!_isStopped);
            }

            private decimal GenerateValue()
            {
                return (decimal)(20 + _random.NextDouble()*60);
            }

            public void Stop()
            {
                _isStopped = true;
            }

            public event MarketUpdate OnMarketUpdate;
        }

        public static void Run()
        {
            var timer = new MarketTimer();

            timer.OnMarketUpdate += Print;

            Thread t = new Thread(timer.Run);

            t.Start();

            Console.ReadKey();

            timer.OnMarketUpdate -= Print;

            Console.ReadKey();

            timer.Stop();
        }

        private static void Print(decimal value)
        {
            Console.WriteLine(value);
        }
    }
}