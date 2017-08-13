using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lessons._10
{
    public class TaskG
    {

        private const string patern = @"^(?:[A-Z][a-z]*\b ?){1,3}$";

        public static void Run()
        {
            Console.WriteLine(IsValidName("Kent Beck")); // true
            Console.WriteLine(IsValidName("Kent")); // true
            Console.WriteLine(IsValidName("Kent Beck Jr")); // true
            Console.WriteLine(IsValidName("KentBeck")); // false
            Console.WriteLine(IsValidName("Kent  Beck")); // false (two spaces)
            Console.WriteLine(IsValidName("Kent Beck Beck Beck")); // false (too many words)
            Console.WriteLine(IsValidName("Kent BECK")); // false (upper chars on other positions in the word)
        }

        private static bool IsValidName(string text)
        {
            //patern
            var reg = new Regex(patern);

            return reg.IsMatch(text);
        }
    }
}