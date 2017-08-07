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
			return Regex.IsMatch(@string, @"^[A-Z][a-z]*?(\s[A-Z][a-z]*?(\s[A-Z][a-z]*?)?)?$");
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
