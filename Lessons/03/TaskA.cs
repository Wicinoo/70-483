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
            var startableSingletonWithLocks = new StartableSingletonWithLocks();
            var randomGenerator = new Random();

            Parallel.For(0, 20, _ =>
            {
                var randomNumber = randomGenerator.Next(100);
                Thread.Sleep(randomNumber);

                var start = randomNumber % 2 == 0;

                if (start)
                {
                    startableSingleton.Start();
                    //startableSingletonWithLocks.Start();
                }
                else
                {
                    startableSingleton.Stop();
                    //startableSingletonWithLocks.Stop();
                }
            });
        }
    }

    public class StartableSingletonWithLocks
    {
        private SingletonState SingletonState;

        public StartableSingletonWithLocks()
        {
            SingletonState = new SingletonState(false);
        }

        public void Start()
        {
            lock (SingletonState)
            {
                if (!SingletonState.HasStarted)
                {
                    Console.WriteLine("Starting ... From singleton with locks");
                    Thread.Sleep(10);
                    SingletonState.HasStarted = true;
                }
                else
                {
                    Console.WriteLine("Refused as it has already been started. From singleton with locks");
                }

                return;
            } 
        }

        public void Stop()
        {
            lock (SingletonState)
            {
                if (SingletonState.HasStarted)
                {
                    Console.WriteLine("Stopping ... From singleton with locks");
                    Thread.Sleep(10);
                    SingletonState.HasStarted = false;
                } else
                {
                    Console.WriteLine("Refused as it has not started yet. From singleton with locks");
                }
            }
        }
    }


    public class StartableSingleton
    {
        private bool _hasStarted;

        public void Start()
        {
            if (!_hasStarted)
            {
                Console.WriteLine("Starting ...");
                Thread.Sleep(10);
                _hasStarted = true;
            }
            else 
            {
                Console.WriteLine("Refused as it has already been started.");
            }        
        }

        public void Stop()
        {
            if (_hasStarted)
            {
                Console.WriteLine("Stopping ...");
                Thread.Sleep(10);
                _hasStarted = false;
            }
            else
            {
                Console.WriteLine("Refused as it has not started yet.");
            }
        }
    }

    public class SingletonState
    {
        public bool HasStarted { get; set; }

        public SingletonState(bool hasStarted)
        {
            HasStarted = hasStarted;
        }
    }
}
