using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace Lessons._10
{
    public class TaskCD
    {
        public static void Run()
        {
            Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary")); // "USA with Trump"
            Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary")); // "TrumpHillaryTrumpTrump"
            Console.WriteLine("Hello \t42".ApplyCrazyMapping()); // "hhello##"
        }
    }

    public static class StringExtension
    {
        public static string RemoveLastOccurrence(this string source, string expr)
        {
            return source.Substring(0,source.LastIndexOf(expr, StringComparison.InvariantCulture));
        }

        public static string ApplyCrazyMapping(this string source)
        {
            var array = source.ToCharArray().Select(x => char.IsDigit(x) ? '#' : x);
            array = array.SelectMany(x =>  Enumerable.Repeat(char.IsUpper(x) ? Char.ToLower(x) : x, char.IsUpper(x) ? 2 : 1));
            return String.Concat(array.Where(x => !char.IsWhiteSpace(x)));
        }
    }
}
