using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskD
    {
        public static void Run()
        {
            Console.Write("Hello \t42".ApplyCrazyMapping()); // "hhello##"
        }
    }

    public static class TaskDStringExtensions
    {
        public static string ApplyCrazyMapping(this string input)
        {
            if (input == null) return null;
            return input.DigitsToHash().UpperCharsToDoubleLowerChars().RemoveWhiteSpace();
        }

        public static string DigitsToHash(this string input)
        {
            if (input == null) return null;
            return new string(input.Select(x => char.IsDigit(x) ? '#' : x).ToArray());
        }

        public static string UpperCharsToDoubleLowerChars(this string input)
        {
            if (input == null) return null;
            return string.Concat(input.Select(x => char.IsUpper(x) ? new string(char.ToLower(x), 2) : new string(x, 1)));
        }

        public static string RemoveWhiteSpace(this string input)
        {
            if (input == null) return null;
            return new string(input.Where(x => !char.IsWhiteSpace(x)).ToArray());
        }
    }
}
