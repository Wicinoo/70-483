using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
	public class ActionMeasurer {
		public static TimeSpan Measure(Action actionToMeasure) {
			DateTime start = DateTime.Now;
			actionToMeasure();

			return DateTime.Now - start;
		}
	}

	public class TaskAB {
		private static readonly Random random = new Random();

		public static String GetRandomString(int length) {
			const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public static void Run() {
			List<String> randomStrings = Enumerable.Range(1, 10000).Select(_ => GetRandomString(10)).ToList();

			Console.WriteLine(ActionMeasurer.Measure(() => {
				String res = String.Empty;

				randomStrings.ForEach(x => res += "x");
			}));

			Console.WriteLine(ActionMeasurer.Measure(() => {
				StringBuilder sb = new StringBuilder();

				randomStrings.ForEach(x => sb.Append("x"));
				
			}));

			Console.WriteLine(ActionMeasurer.Measure(() => {
				String res = String.Empty;

				randomStrings.ForEach(x => res = String.Concat(res, "x"));
			}));

			
			Console.WriteLine(ActionMeasurer.Measure(() => {
				String res = String.Empty;

				randomStrings.ForEach(x => res += x);
			}));

			Console.WriteLine(ActionMeasurer.Measure(() => {
				StringBuilder builder = new StringBuilder();

				randomStrings.ForEach(x => builder.Append(x));
				builder.ToString();
			}));

			Console.WriteLine(ActionMeasurer.Measure(() => {
				String res = String.Empty;

				randomStrings.ForEach(x => res = String.Concat(res, x));
			}));
		}

	}
}
