using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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

        private class MarketUpdater
        {
            private bool _isRunning;

            private Random _randomizer = new Random(DateTime.Now.Millisecond);

            private decimal GenerateValueBetween20And80()
            {
                return (decimal) (_randomizer.Next(20, 79) + _randomizer.NextDouble());
            }

            public void Stop()
            {
                _isRunning = false;
            }

            private bool IsRunning()
            {
                return _isRunning;
            }

            public void Run()
            {
                _isRunning = true;

                do
                {
                    var value = GenerateValueBetween20And80();
                    OnMarketUpdate?.Invoke(value);

                    Thread.Sleep(1000);
                    
                } while (IsRunning());
            }

            public event MarketUpdate OnMarketUpdate;
        }

        public static void Run()
        {
            var updater = new MarketUpdater();


            updater.OnMarketUpdate += PrintMarketValue;

            var thread = new Thread(updater.Run);
            thread.Start();

            Console.ReadKey();

            updater.OnMarketUpdate -= PrintMarketValue;

            Console.ReadKey();

            updater.Stop();
        }


        private static void PrintMarketValue(decimal value)
        {
            Console.WriteLine("Market value is: {0}", value);
        }
    }
}