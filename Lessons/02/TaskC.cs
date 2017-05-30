using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        private static readonly List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        private static readonly ConcurrentStack<int> ConcurrentStackNumbers = new ConcurrentStack<int>(Numbers);
        public static void Run()
        {
            DoStuffThatFails();

            DoStuffThatWorks();
        }

        private static void DoStuffThatWorks()
        {
            Console.WriteLine();
            Console.WriteLine("****");
            Console.WriteLine("Doing Stuff That Works");
            Parallel.ForEach(ConcurrentStackNumbers, StuffThatWorks);
            Console.WriteLine("ConcurrentStackNumbers Status : {0}" , ConcurrentStackNumbers.IsEmpty ? "Empty" : "Not Empty");
            Console.WriteLine("****");
        }

        private static void DoStuffThatFails()
        {
            Console.WriteLine("****");
            Console.WriteLine("Doing Stuff That Fails");

            try
            {
                Parallel.ForEach(Numbers, StuffThatFails);
            }
            catch (AggregateException exception)
            {
                Console.WriteLine("Aggregate Exception Messages");
                foreach (var innerException in exception.InnerExceptions)
                {
                    Console.WriteLine(innerException.ToString());
                }
                Console.WriteLine("****");
            }
        }

        private static void StuffThatWorks(int number)
        {
            int result;
            ConcurrentStackNumbers.TryPop(out result);
        }

        private static void StuffThatFails(int number)
        {
            Numbers.Remove(number);
        }
    }
}