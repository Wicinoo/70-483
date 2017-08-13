using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class B
    {
        //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
        private static Random random = new Random();
        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        List<string> randomStrings = Enumerable.Range(1, 10000).Select(_ => GetRandomString(10)).ToList();


        public B()
        {

            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }

        void joining10000StringsBySimpleAssignmentAction()
        {
            var temp = randomStrings[0];

            for (int i = 0; i < 10000; i++)
            {
                temp += randomStrings[i];
            }
        }

        void joining10000StringsByStringBuilderAction()
        {
            var sb = new StringBuilder(randomStrings[0]);

            for (int i = 0; i < 10000; i++)
            {
                sb.Append(randomStrings[i]);
            }
        }

        void joining10000StringsByConcatAction()
        {
            var temp = randomStrings[0];

            for (int i = 0; i < 10000; i++)
            {
                temp = string.Concat(temp, randomStrings[i]);
            }
        }
    }
}
