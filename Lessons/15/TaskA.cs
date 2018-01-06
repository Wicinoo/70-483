//A.Write an method extending LINQ to rotate elements in a collection by given positions:
//(new[] {1, 2, 3, 4, 5}).Rotate(2); // expected: {4, 5, 1, 2, 3}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Castle.Core.Internal;

namespace Lessons._15
{
    public static class TaskA
    {
        public static void Run()
        {
            var stuffToRotate = new[] { 1, 2, 3, 4, 5 };
            var rotatedStuff = stuffToRotate.Rotate(3).Print();
            Waiter.WaitForAnyKey();
        }

        public static IEnumerable<T> Rotate<T>(this IEnumerable<T> source, int shift)
        {
            shift = source.Count() - shift % source.Count();
            return source.Skip(shift).Concat(source.Take(shift));
        }

        public static IEnumerable<T> Print<T>(this IEnumerable<T> source)
        {
            source.ForEach(x => Console.WriteLine(x));
            return source;
        }
    }
}
