//D.Write a string extension method:
//- to map digits to #.
//- to map upper chars to double lower ones.
//- to ignore whitespace characters.

//Use LINQ to iterate over a string. Use static methods of Char type.Examples: 

//"Hello \t42".ApplyCrazyMapping(); // "hhello##"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    static class TaskD
    {
       public static void Run()
        {
            Console.WriteLine("Hello \t42".ApplyCrazyMapping()); // "hhello##")

        }
    }

    public static class StringExtensions2   
    {
        public static string ApplyCrazyMapping(this string value)
        {
            value = ReplaceDigits(value, '#');
            value = UpperCharToDoubleLower(value);
            value = IgnoreWhiteSpace(value);

            return value;

        }

        private static string IgnoreWhiteSpace(string value)
        {
            var whiteSpace = value.Where(c => char.IsWhiteSpace(c));
            foreach (var item in whiteSpace)
            {
                int index = value.IndexOf(item);
                value = value.Remove(index, 1);
            }
            return value;
        }
        private static string UpperCharToDoubleLower(string value)
        {
            var upperChar = value.Where(c => char.IsUpper(c));
            foreach (char item in upperChar)
            {
                string old = item.ToString();
                string newForReplace = char.ToLower(item).ToString();
                value = value.Replace(old, newForReplace + newForReplace);
            }
            return value;
        }

        private static string ReplaceDigits(string value, char newSymbol)
        {
            var digits = value.Where(c => char.IsDigit(c));
            foreach (var item in digits)
            {
                value = value.Replace(item, newSymbol);
            }
            return value;
        }
    }
}
