using System;

namespace Lessons._10
{
    internal class TaskC
    {
        public static void Run()
        {
            Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary")); // "USA with Trump")

            Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary")); // "TrumpHillaryTrumpTrump"
        }
    }
}
