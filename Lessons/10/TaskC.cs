using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
	public static class TaskC
	{
		public static string RemoveLastOccurrence(this string @string, string pattern)
		{
			if (String.IsNullOrEmpty(@string))
				throw new InvalidOperationException("The string is empty you idiot");

			if (@string.LastIndexOf(pattern) > 0)
			{
				return @string.Remove(@string.LastIndexOf(pattern), pattern.Length);
			}
			return @string;
		}

		public static void Run()
		{
			Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary")); // "USA with Trump"

			Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary")); // "TrumpHillaryTrumpTrump"
		}

	}
}
