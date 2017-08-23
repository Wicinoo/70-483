using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
	public static class TaskC {
		public static string RemoveLastOccurrence(this String @string, String pattern) {
		    if (String.IsNullOrEmpty(@string)) {
		        throw new ArgumentException("@string is empty/null");
		    }

		    return @string.LastIndexOf(pattern, StringComparison.InvariantCultureIgnoreCase) > 0 ? @string.Remove(@string.LastIndexOf(pattern, StringComparison.InvariantCultureIgnoreCase), pattern.Length) : @string;
		}

		public static void Run() {
			Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary"));
			Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary")); 
		}

	}
}
