using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._03
{
    public class Demo
    {
        public static void Run()
        {
            // Atomic vs non-atomic operations

            var n = 0;
            const int changes = 1000000;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < changes; i++)
                {
                    n++;
                }
            });

            for (int i = 0; i < changes; i++)
            {
                n--;
            }

            up.Wait();

            Console.WriteLine(n);

            // Locks, monitors, System.Thread.Volatile

            // Interlocked

            var n3 = 0;

            var up3 = Task.Run(() =>
            {
                for (int i = 0; i < changes; i++)
                {
                    Interlocked.Increment(ref n3);
                }
            });

            for (int i = 0; i < changes; i++)
            {
                Interlocked.Decrement(ref n3);
            }

            up3.Wait();

            Console.WriteLine(n3);

            // Deadlock

            object lockA = new object();
            object lockB = new object();

            var up2 = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            up2.Wait();

            // CancellationToken

            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            var task = Task.Run(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        Console.Write("*");
                        Thread.Sleep(1000);
                    }

                    token.ThrowIfCancellationRequested();

                }, token)
            .ContinueWith(taskResult =>
                {
                    taskResult.Exception.Handle(_ => true);
                    Console.WriteLine("Cancelled");
                }, TaskContinuationOptions.OnlyOnCanceled);

            Console.ReadKey();
            cancellationTokenSource.Cancel();

            // Short-circuiting evaluation

            var x = 0;
            if (IsFalse() && (x = GetValue()) > 0) { }
            if (IsTrue() || (x = GetValue()) > 0) { }

            var s = default(string);

            if (s.StartsWith("a")) Console.WriteLine("Starts with A");

            Console.WriteLine(x);

            // Branching, if, switch

            // Loops, while, do while, for, foreach

            // Jumps, break, continue, goto

            // null-coalescing operator ??
            // conditional operator ?:
        }

        private static bool IsTrue()
        {
            return true;
        }

        private static bool IsFalse()
        {
            return false;
        }

        private static int GetValue()
        {
            return 42;
        }

        private void HowToDecreaseCyclomaticComplexity()
        {
            var currentDayOfWeek = DateTime.Now.DayOfWeek;

            var rules = new Dictionary<DayOfWeek, Action>();
            rules.Add(DayOfWeek.Sunday, () => Console.WriteLine("it is Sunday"));
            var actionForCurrentDay = rules[currentDayOfWeek];
            actionForCurrentDay();

            switch (currentDayOfWeek)
            {
                case DayOfWeek.Sunday:
                    break;
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    break;
                case DayOfWeek.Wednesday:
                    break;
                case DayOfWeek.Thursday:
                    break;
                case DayOfWeek.Friday:
                    break;
                case DayOfWeek.Saturday:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}