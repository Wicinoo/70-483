using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskC
    {
        public static void Run()
        {
            Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary")); // "USA with Trump"

            Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary")); // "TrumpHillaryTrumpTrump"
        }
    }

    public static class StringExtensions
    {
        public static string RemoveLastOccurrence(this string inputString, string stringToRemove)
        {
            if (inputString == null) return null;
            if (stringToRemove == null) throw new ArgumentNullException(nameof(stringToRemove));

            int index = inputString.LastIndexOf(stringToRemove);
            return index > -1 ? inputString.Remove(index, stringToRemove.Length) : inputString;
        }
    }
}
