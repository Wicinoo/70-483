//B.Write an method extending LINQ to slice elements in a collection:
//(new[] {1, 2, 3, 4, 5}).Slice(2); // expected: {{1, 2}, {3, 4}, {5}}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;

namespace Lessons._15
{
    public static class TaskB
    {
        public static void Run()
        {
            var stuffToSlice = new[] { 1, 2, 3, 4, 5 };
            var slicedStuff = stuffToSlice.Slice(2);
            int index = 0;

            foreach (var stuff in slicedStuff)
            { 
                Console.WriteLine("Index i = {0}", index);
                stuff.Print();
                index++;
            }

            Waiter.WaitForAnyKey();
        }

        public static IList<IEnumerable<T>> Slice<T>(this IEnumerable<T> source, int count)
        {
            IList<IEnumerable<T>> result = new List<IEnumerable<T>>();
            source = source.ToList();
            var numParts = source.Count() / count;
            result.Add(source.Take(count));
            if (numParts > 0)
            {
                source.Skip(count).Slice(count).ForEach(x => result.Add(x));
            }
            return result;
        }
    }
}
