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
        public static PricePublisher pricePublisher { get; set; }

        public static void Run()
        {
            pricePublisher = new PricePublisher();
            pricePublisher.OnMarketUpdated += PrintNewPrice;
            pricePublisher.OnKeyPressed += PricePublisher_OnKeyPressed;

            pricePublisher.Run();
        }

        private static void PricePublisher_OnKeyPressed()
        {
            pricePublisher.OnMarketUpdated -= PrintNewPrice;
            Console.WriteLine("Unsubbed from OnMarkedUpdated.");
        }

        private static void PrintNewPrice(int price)
        {
            Console.WriteLine($"New price is: {price}");
        }
    }

    public class PricePublisher
    {
        public event Action<int> OnMarketUpdated;
        public event Action OnKeyPressed;

        private int price { get; set; }

        public void Run()
        {
            while (!(Console.KeyAvailable && Console.ReadKey() != null))
            {
                Thread.Sleep(1000);
                ChangePrice();
            }

            if (OnKeyPressed != null)
            {
                OnKeyPressed();
            }
        }

        private void ChangePrice()
        {
            Random r = new Random();
            price = r.Next(20, 80);

            if (OnMarketUpdated != null)
            {
                OnMarketUpdated(price);
            }
        }
    }
}