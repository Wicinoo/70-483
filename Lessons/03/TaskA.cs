using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    /// <summary>
    /// Change implementation of Start() and Stop() method of StartableSingleton
    /// to be thread-safe.
    /// In case an instance has been already started and Start() is triggered,
    /// it should write "Refused as it has been already started.".
    /// In case an instance has not been started yet and Stop() is triggered,
    /// it should write "Refused as it is not started yet.".
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            var startableSingleton = new StartableSingleton();
            var randomGenerator = new Random();

            Parallel.For(0, 20, _ =>
            {
                var randomNumber = randomGenerator.Next(100);
                Thread.Sleep(randomNumber);

                var start = randomNumber % 2 == 0;

                if (start)
                {
                    startableSingleton.Start();
                }
                else
                {
                    startableSingleton.Stop();

                }
            });
        }
    }

    public class StartableSingleton
    {
        private ReferencedBool _isStarted = ReferencedBool.False;

        public void Start()
        {
            if (Interlocked.CompareExchange(ref _isStarted, ReferencedBool.True, ReferencedBool.False).Value)
            {
                Console.WriteLine("Refused as it has been already started.");
            }
            else
            {
                Console.WriteLine("Starting ...");
            }
            Thread.Sleep(10);

        }

        public void Stop()
        {
            if (Interlocked.CompareExchange(ref _isStarted, ReferencedBool.False, ReferencedBool.True).Value)
            {
                Console.WriteLine("Stopping ...");
            }
            else
            {
                Console.WriteLine("Refused as it is not started yet.");

            }
            Thread.Sleep(10);
        }
    }

    public class ReferencedBool
    {
        private readonly bool _value;

        public static ReferencedBool True = new ReferencedBool(true);
        public static ReferencedBool False = new ReferencedBool(false);

        private ReferencedBool(bool value)
        {
            _value = value;
        }

        public bool Value { get { return _value; } }

        public override bool Equals(object obj)
        {
            if (obj is ReferencedBool)
            {
                var other = (ReferencedBool)obj;
                return _value == other._value;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _value ? 1 : 0;
        }
    }
}
