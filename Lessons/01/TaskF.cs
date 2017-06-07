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
            Action getRandomNumber = () => Console.WriteLine(new Random().Next(20, 80)); // TODO consume random number from some function via event arg
            bool tickGeneratorStopped = false;

            MarketPublisher marketPublisher = new MarketPublisher();

            Thread tickGenerator = new Thread(
                new ThreadStart(
                    () =>
                    {
                        while (!tickGeneratorStopped)
                        {
                            marketPublisher.Raise();
                            Thread.Sleep(1000);
                        }
                    }));

            marketPublisher.OnEvent += getRandomNumber; // subscribe

            tickGenerator.Start();

            Console.ReadKey();

            marketPublisher.OnEvent -= getRandomNumber; // unsubscribe


            Console.ReadKey();
            tickGeneratorStopped = true;
            tickGenerator.Join();
        }
    }

    public class MarketPublisher
    {
        public event Action OnEvent;

        public void Raise()
        {
            OnEvent?.Invoke();
        }
    }
}