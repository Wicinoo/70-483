using System;

namespace Lessons._15
{
    public static class Waiter
    {
        public static void WaitForAnyKey()
        {
            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}