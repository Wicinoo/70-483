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
            var publisher = new Pub();

            EventHandler<MyArgs> methodToRegisterUnregister = (sender, args) => { Console.WriteLine(args.Value); };

            publisher.OnMarketUpdated += methodToRegisterUnregister;
            publisher.TimerEnabled = true;

            var myOtherThread = new Thread(publisher.Raise);

            myOtherThread.Start();

            Console.ReadKey();

            publisher.OnMarketUpdated -= methodToRegisterUnregister;

            Console.ReadKey();

            publisher.TimerEnabled = false;

            myOtherThread.Join();
        }
    }

    public class MyArgs : EventArgs
    {
        public MyArgs(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }

    public class Pub
    {
        public event EventHandler<MyArgs> OnMarketUpdated = delegate { };
        public void Raise()
        {
            OnMarketUpdated(this, new MyArgs(new Random().Next(20, 80).ToString()));

            if (TimerEnabled)
            {
                Thread.Sleep(1000);
                Raise();
            }
        }

        public bool TimerEnabled { get; set; }
    }
}