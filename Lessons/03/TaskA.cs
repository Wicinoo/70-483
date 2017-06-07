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
        public static void Run() {
            var singleInstanceRunner = new SingleInstanceRunner();
            var random = new Random();

            Parallel.For(0, 20, _ => {
                var randomNumber = random.Next(100);
                Thread.Sleep(randomNumber);

                var start = randomNumber % 2 == 0;

                if (start) {
                    singleInstanceRunner.Start();
                } else {
                    singleInstanceRunner.Stop();
                }
            });
        }
    }

    public class SingleInstanceRunner {
        private volatile bool _isStarted;
        private readonly object stateLock = new Object();

        public void Start() {    
            Console.WriteLine("Here I am, baby...");
            Thread.Sleep(22);

            lock (stateLock) {
                if (!_isStarted)
                {
                    _isStarted = true;
                } else {
                    Console.WriteLine("Come on, there can be only one of my kind.");
                }
            }
        }

        public void Stop() {   
            Console.WriteLine("Damn, see you then...");
            Thread.Sleep(22);

            lock (stateLock) {
                if (_isStarted) {
                    _isStarted = false;
                } else {
                    Console.WriteLine("Hey man, I am not alive yet.");
                }
            }
        }
    }
}
