using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lessons._10
{
	public class TaskG {
		public static bool IsValidName(String @string) {
			return Regex.IsMatch(@string, @"^[A-Z][a-z]*?(\s[A-Z][a-z]*?(\s[A-Z][a-z]*?)?)?$");
		}

		public static void Run() {
			Console.WriteLine(IsValidName("Kent Beck")); 
			Console.WriteLine(IsValidName("Kent")); 
			Console.WriteLine(IsValidName("Kent Beck Jr")); 
			Console.WriteLine(IsValidName("KentBeck"));
			Console.WriteLine(IsValidName("Kent  Beck")); 
			Console.WriteLine(IsValidName("Kent Beck Beck Beck"));
			Console.WriteLine(IsValidName("Kent BECK"));
		}
	}
}
