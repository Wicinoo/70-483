using System;
using System.Linq;

namespace Lessons._02
{
    public static class _13_ParallelLinqExample
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(0, 10);

            var parallelResult = numbers.AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }
    }
}