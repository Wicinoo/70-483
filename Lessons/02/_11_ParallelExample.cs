using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    public static class _11_ParallelExample
    {
        public static void Run()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("For: {0}", i);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ForEach: {0}", i);
            });
        }
    }
}