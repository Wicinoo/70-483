using System;
using System.Linq;
using System.Text;

namespace Lessons._10
{
    internal class TaskB
    {
        public static void Run()
        {
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();

            Action joiningRandomStringsBySimpleAssignment = 
            () =>
                {                   
                    var result = string.Empty;
                    foreach (var randomString in randomStrings)
                    {
                        result += randomString;
                    }
                };

            Action joiningRandomStringsByStringBuilder =
            () =>
            {
                var sB = new StringBuilder();
                foreach (var randomString in randomStrings)
                {

                    sB.Append(randomString);
                }
            };

            Action joiningRandomStringsByConcat = () =>
                {
                    var result = string.Empty;
                    foreach (var randomString in randomStrings)
                    {

                        result = string.Concat(result, randomString);
                    }
                };

            Console.WriteLine("+=");
            Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsBySimpleAssignment));
            Console.WriteLine("sb");
            Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsByStringBuilder));
            Console.WriteLine("concat");
            Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsByConcat));
        }

        private static string GetRandomString(int length)
        {
            var chars = GetChars();
            var charLength = chars.Length;
            var rnd = new Random(new System.DateTime().Millisecond);

            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[rnd.Next(charLength)];
            }

            return result.ToString();
        }

        private static char[] GetChars()
        {
            var charsBuilder = new StringBuilder();
            for (int ch = 0x30; ch <= 0x39; ch++)
            {
                charsBuilder.Append(ch);
            }
            for (int ch = 0x41; ch <= 0x5A; ch++)
            {
                charsBuilder.Append(ch);
            }
            for (int ch = 0x61; ch <= 0x7A; ch++)
            {
                charsBuilder.Append(ch);
            }

            return charsBuilder.ToString().ToCharArray();
        }
    }
}
