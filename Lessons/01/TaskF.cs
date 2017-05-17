using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

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
            var marketHandler = new MarketHandler()
            {
                IsRunning = true
            };

            MarketUpdate.OnMarketUpdated += Printer;

            Thread t = new Thread(marketHandler.RaiseInLoop);
            t.Start();

            Console.ReadLine();
            MarketUpdate.OnMarketUpdated -= Printer;
            Console.ReadLine();
            marketHandler.IsRunning = false;
        }



        public static void Printer(int number)
        {
            Console.WriteLine(number);
        }
    }

    public class MarketHandler
    {
        public bool IsRunning { get; set; }
        public void RaiseInLoop()
        {
            var rand = new Random();

            while (IsRunning)
            {
                Thread.Sleep(1000);
                MarketUpdate.Raise(rand.Next(20, 80));
            }
        }
    }
    public class MarketUpdate
    {
        public static event Action<int> OnMarketUpdated;

        public static void Raise(int x)
        {
            OnMarketUpdated?.Invoke(x);
        }
    }
}