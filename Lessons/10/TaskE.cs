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
			
			cultures.ForEach(x =>
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(x);
				formats.ForEach(y =>
				{
					Console.WriteLine("{0}:{1}", x, DateTime.Now.ToString(y));
				});
				
			});
		}
	}
}
