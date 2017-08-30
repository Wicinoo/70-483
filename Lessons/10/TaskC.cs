//C.Write a string extension method to remove last occurrence of a substring.Examples: 

//"USA with TrumpHillary".RemoveLastOccurrence("Hillary"); // "USA with Trump"

//"TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary"); // "TrumpHillaryTrumpTrump"


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
	public static class TaskC
	{
		public static string RemoveLastOccurrence(this string text, string toRemove)
		{
			if (String.IsNullOrEmpty(text))
				return text;
      var index = text.LastIndexOf(toRemove);
			if (index >= 0)
			{
				return text.Remove(index, toRemove.Length);
			}
			return text;
		}

		public static void Run()
		{
			Console.WriteLine("USA with TrumpHillary".RemoveLastOccurrence("Hillary"));

			Console.WriteLine("TrumpHillaryTrumpHillaryTrump".RemoveLastOccurrence("Hillary"));
		}

	}
}
