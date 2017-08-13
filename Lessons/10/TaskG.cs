using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskG
    {
        public static bool IsValidName(string s)
        {
            var r = Regex.IsMatch(s, @"^([A-Z][a-z]+?){1,3}( [A-Z][a-z]+( [A-Z][a-z]+)?)?$");
            Console.WriteLine(r.ToString());

            return r;
        }

        public static void Run()
        {
            IsValidName("Kent Beck"); // true
            IsValidName("Kent"); // true
            IsValidName("Kent Beck Jr"); // true
            IsValidName("KentBeck"); // false
            IsValidName("Kent  Beck"); // false (two spaces)
            IsValidName("Kent Beck Beck Beck"); // false (too many words)
            IsValidName("Kent BECK"); // false (upper chars on other positions in the wor
        }
    }
}
