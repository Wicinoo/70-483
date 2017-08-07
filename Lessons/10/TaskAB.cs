using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
	public class DurationMeasurer
	{
		public static TimeSpan Measure(Action actionToMeasure)
		{
			var start = DateTime.Now;

			actionToMeasure();

			return DateTime.Now - start;
		}
	}

	public class TaskAB
	{
		private static Random random = new Random();
		public static string GetRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public static void Run()
		{

			List<string> randomStrings = Enumerable.Range(1, 10000).Select(_ => GetRandomString(10)).ToList();

			// I am too lazy to do separate itearation of 10000 so there
			Console.WriteLine(DurationMeasurer.Measure(() => {
				var res = String.Empty;

				randomStrings.ForEach(x => res += "x");
			}));

			Console.WriteLine(DurationMeasurer.Measure(() => {
				var sb = new StringBuilder();

				randomStrings.ForEach(x => sb.Append("x"));
				
			}));

			Console.WriteLine(DurationMeasurer.Measure(() => {
				var res = String.Empty;

				randomStrings.ForEach(x => res = String.Concat(res, "x"));
			}));

			
			Console.WriteLine(DurationMeasurer.Measure(() => {
				var res = String.Empty;

				randomStrings.ForEach(x => res += x);
			}));

			Console.WriteLine(DurationMeasurer.Measure(() => {
				var sb = new StringBuilder();

				randomStrings.ForEach(x => sb.Append(x));
				sb.ToString();
			}));

			Console.WriteLine(DurationMeasurer.Measure(() => {
				var res = String.Empty;

				randomStrings.ForEach(x => res = String.Concat(res, x));
			}));
		}

	}
}
