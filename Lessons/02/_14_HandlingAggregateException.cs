using System;
using System.Linq;

namespace Lessons._02
{
    public static class _14_HandlingAggregateException
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var evenNumbers = numbers
                    .AsParallel()
                    .Where(number => IsEven(number));

                evenNumbers.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }

        private static bool IsEven(int number)
        {
            if (number % 10 == 0) throw new ArgumentException("number");

            return number % 2 == 0;
        }
    }
}