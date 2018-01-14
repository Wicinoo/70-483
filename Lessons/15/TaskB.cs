//B.Write an method extending LINQ to slice elements in a collection:
//(new[] {1, 2, 3, 4, 5}).Slice(2); // expected: {{1, 2}, {3, 4}, {5}}

using System;

namespace Lessons._15
{
    public static class TaskB
    {
        public static void Run()
        {
            var stuffToSlice = new[] { 1, 2, 3, 4, 5 };
            //var slicedStuff = stuffToSlice.Slice(2);
            int index = 0;

            //foreach (var stuff in slicedStuff)
            //{
            //    Console.WriteLine("Index i = {0}, value = {1}", index, stuff);
            //    index++;
            //}

            Waiter.WaitForAnyKey();
        }
    }
}
