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
		public static string ApplyCrazyMapping(this string @string)
		{
			var str = Regex.Replace(@string, "[A-Z]", x => String.Format("{0}{0}",x.ToString().ToLower()));
			str = Regex.Replace(str, "[0-9]", x => "#");
			str = Regex.Replace(str, @"[\s]", x => String.Empty);
			return str;
		}

		public static void Run()
		{
			Console.WriteLine("Hello \t42".ApplyCrazyMapping());
		}

	}
}
