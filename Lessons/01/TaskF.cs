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
            var timer = new Timer(1000);
            timer.Elapsed += OnMarketUpdated;
            timer.Enabled = true;

            Console.ReadLine();
            timer.Elapsed -= OnMarketUpdated;
        }

        public static void OnMarketUpdated(object sender, EventArgs e)
        {
            Console.WriteLine($"Current market value: {new Random().Next(20, 80)}");
        }
    }
}