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
        private bool _isStarted;

        private object @lock = new object();

        public void Start()
        {
            lock (@lock)
            {
                Console.WriteLine(_isStarted ? "Refused as it has been already started." : "Starting ...");
            }
            Thread.Sleep(10);
            lock (@lock)
            {
                _isStarted = true;
            }
        }

        public void Stop()
        {
            lock (@lock)
            {
                Console.WriteLine(_isStarted ? "Stopping ..." : "Refused as it is not started yet." );
            }
            Thread.Sleep(10);
            lock (@lock)
            {
                _isStarted = false;
            }
        }
    }
}
