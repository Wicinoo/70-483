
//E.Print the current date in these cultures:
//- English - United Kingdom
//- English - United States
//- Czech - Czech Republic
//- Chinese - Singapore

//For each culture use these formats:
//- long date
//- full date long
//- ISO 8601
//- year month

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace Lessons._10
{
	public class TaskE
	{
		public static void Run()
		{
			List<string> cultures = new List<string> { "en-GB", "en-US", "cs-CZ", "zh-SG" };
			List<string> formats = new List<string> { "D", "F", "s", "yyyy-MM"};
			
      DateTime date = DateTime.Now;
      foreach(var culture in cultures)
      {
         Console.WriteLine(culture);
         foreach(var format in formats)
         {
           Console.WriteLine("\t"+format+": "+date.ToString(format, culture));
         }
      }
      
		}
	}
}
