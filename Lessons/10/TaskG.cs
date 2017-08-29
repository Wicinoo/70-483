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
        public static void Run()
        {
            IsValidName("Kent Beck"); // true
            IsValidName("Kent"); // true
            IsValidName("Kent Beck Jr"); // true
            IsValidName("KentBeck"); // false
            IsValidName("Kent  Beck"); // false (two spaces)
            IsValidName("Kent Beck Beck Beck"); // false (too many words)
            IsValidName("Kent BECK"); // false (upper chars on other positions in the word)
        }

        public static bool IsValidName(string fullName)
        {
            Regex regex = new Regex("^[A-Z][a-z]{3,}(?: [A-Z][a-z]*){0,2}$");
            bool result = regex.IsMatch(fullName);
            Console.WriteLine($"{fullName} - {result}");
            return result;
        }
    }
}
