using System;

namespace Lessons._11
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