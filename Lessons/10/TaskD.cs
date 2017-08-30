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
using System.Text.RegularExpressions;
namespace Lessons._10
{
	public static class TaskD
	{
		public static string ApplyCrazyMapping(this string text)
		{
			var ret = Regex.Replace(@string, "[A-Z]", x => String.Format("{0}{0}",x.ToString().ToLower()));
			ret = Regex.Replace(ret, "[0-9]", "#");
			ret = Regex.Replace(ret, "[\\s]", String.Empty);
			return ret;
		}

		public static void Run()
		{
			Console.WriteLine("Hello \t42".ApplyCrazyMapping());
		}

	}
}
