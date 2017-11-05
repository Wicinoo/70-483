//A.Write an method extending LINQ to rotate elements in a collection by given positions:
//(new[] {1, 2, 3, 4, 5}).Rotate(2); // expected: {4, 5, 1, 2, 3}

using System;
using System.Collections.Generic;

namespace Lessons._15
{
    public static class TaskA
    {


        public static void Run()
        {
            var stuffToRotate = new[] {1, 2, 3, 4, 5};
            //var rotatedStuff = stuffToRotate.Rotate(2).Print();
            Waiter.WaitForAnyKey();
        }
    }
}
