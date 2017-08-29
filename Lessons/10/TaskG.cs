//G.Write a method that checks if a string is a valid name with these rules:

//- Only characters a, ..., z and A, ..., Z are allowed in each word
//- Words are delimited by a space.
//- There should be at least one word in a name.
//- There should be maximal three words in a name.
//- Upper characters should be only at the beginning of a word.

//Use a regular expression. 

//Examples:
//IsValidName("Kent Beck"); // true
//IsValidName("Kent"); // true
//IsValidName("Kent Beck Jr"); // true
//IsValidName("KentBeck"); // false
//IsValidName("Kent  Beck"); // false (two spaces)
//IsValidName("Kent Beck Beck Beck"); // false (too many words)
//IsValidName("Kent BECK"); // false (upper chars on other positions in the word)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    static class TaskG
    {
        public static void Run()
        {
            string name = "test";
            Console.WriteLine(IsValidName(name));

        }

        private static bool IsValidName(string name)
        {

            if (!VlidateAllowedCharacters(name)) return false;
            if (!ValidateDelimitedByWhiteSpace(name)) return false;
            if (!ValidateDistinctNames(name)) return false;
            if (!ValidateMaximalWords(name)) return false;
            if (!ValidateOneWhiteSpaceBetweenWords(name)) return false;
            if (!ValidateUpperCharsInName(name)) return false;
            return true;
        }

        private static bool ValidateOneWhiteSpaceBetweenWords(string name)
        {
            throw new NotImplementedException();
        }

        private static bool ValidateUpperCharsInName(string name)
        {
            return false;
         
        }

        private static bool ValidateMaximalWords(string name)
        {
            var allWords = name.Split(' ');
            return allWords.Count() <= 3;
        }

        private static bool ValidateDistinctNames(string name)
        {
            var distinctWords = name.Split(' ').Distinct();
            var allwords = name.Split(' ');
            return (distinctWords.Count() == allwords.Count());
        }

        private static bool ValidateDelimitedByWhiteSpace(string name)
        {
            var upperCase = name.Where(s => char.IsUpper(s));
            foreach (var item in upperCase)
            {
                var index = name.IndexOf(item);
                if (index > 0)
                {
                    if (!char.IsWhiteSpace(name[index - 1]))
                    { return false; }
                }
            }
            return true;
        }

        private static bool VlidateAllowedCharacters(string name)
        {
            var allowedChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (var item in name)
            {
                if (!(allowedChar.Contains(item))) return false;
            }
            return true;
        }
    }
}
