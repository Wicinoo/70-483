using System;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Lessons._10
{
    public class TaskB
    {

        private const string validchars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public static void Run()
        {
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }



        private static void joining10000StringsBySimpleAssignmentAction()
        {
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();

            var result = string.Empty;

            for (int i = 0; i < randomStrings.Count; i++)
            {
                result += randomStrings[i];
            }
        }

        private static void joining10000StringsByStringBuilderAction()
        {
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();

            var sb = new StringBuilder();

            for (int i = 0; i < randomStrings.Count; i++)
            {
                sb.Append(randomStrings[i]);
            }
        }

        private static void joining10000StringsByConcatAction()
        {
            var result = string.Empty;
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();

            for (int i = 0; i < randomStrings.Count; i++)
            {
                result = string.Concat(result, randomStrings[i]);
            }
        }

        private static string GetRandomString(int length)
        {
            var sb = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(validchars[random.Next(0, validchars.Length)]);
            }

            return sb.ToString();

        }
    }
}