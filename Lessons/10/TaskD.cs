using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Lessons._10
{
	public static class TaskD {
		public static String PerformTranslation(this String @string) {
			String finalValue = Regex.Replace(@string, "[A-Z]", x => String.Format("{0}{0}", x.ToString().ToLower()));
			finalValue = Regex.Replace(finalValue, "[0-9]", x => "#");
			finalValue = Regex.Replace(finalValue, @"[\s]", x => String.Empty);

            return finalValue;
		}

		public static void Run() {
			Console.WriteLine("Hello \t42".PerformTranslation());
		}

	}
}
