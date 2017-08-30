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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lessons._10
{
	public class TaskG
	{
		public static bool IsValidName(string @string)
		{
			return Regex.IsMatch(@string, @"^[A-Z][a-z]*(\s[A-Z][a-z]*){0,2}$");
		}

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
	}
}
