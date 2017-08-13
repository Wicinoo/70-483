using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public static class TaskC
    {
        public static void Run()
        {
            Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary")); // "USA with Trump"

            Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary")); // "TrumpHillaryTrumpTrump"
        }
    }

    public static class StringExtension
    {
        public static string RemoveLastOccurrence(this string s, string r)
        {
            return s.Remove(s.LastIndexOf(r), r.Length);
        }
    }
}
