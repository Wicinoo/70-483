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
using System.Text.RegularExpressions;

namespace Lessons._10
{
    static class TaskG
    {
        public static void Run()
        {
            Console.WriteLine("Kent Beck");
            if (IsValidName("Kent Beck")) Console.WriteLine("Ok"); // true

            Console.WriteLine("Kent");
            if (IsValidName("Kent")) Console.WriteLine("Ok"); // true

            Console.WriteLine("Kent Beck Jr");
            if (IsValidName("Kent Beck Jr")) Console.WriteLine("Ok"); // true

            Console.WriteLine("KentBeck");
            if (!IsValidName("KentBeck")) Console.WriteLine("Ok"); // false

            Console.WriteLine("Kent  Beck");
            if (!IsValidName("Kent  Beck")) Console.WriteLine("Ok"); // false (two spaces)

            Console.WriteLine("Kent Beck Beck Beck");
            if (!IsValidName("Kent Beck Beck Beck")) Console.WriteLine("Ok"); // false (too many words)

            Console.WriteLine("Kent BECK");
            if (!IsValidName("Kent BECK")) Console.WriteLine("Ok"); // false (upper chars on other positions in the word)
        }

        private static bool IsValidName(string name)
        {
            //^[A-Z]                 start with upper case
            //[a-z]*                 any repeat for lower case
            //\s[A-Z][a-z]*          \s space 
            //(\s[A-Z][a-z]*){0,2}   maximum 2 repeat
            var pattern = @"^[A-Z][a-z]*(\s[A-Z][a-z]*){0,2}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(name);
        }
    }
}
