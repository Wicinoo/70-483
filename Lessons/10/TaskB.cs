//Change Task A to use non-constant strings.

//So, you have to create a collection of random strings first.
//Then you can compare the approaches. 


//var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();

//...

//Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsBySimpleAssignment));
//Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsByStringBuilder));
//Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsByConcat));



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    class TaskB
    {
        private static List<string> _randomStrings = Enumerable.Range(1, Iterations).Select(_ => GetRandomString(10)).ToList();

     
        const int Iterations = 100000;
        public static void Run()
        {
            RunTest();
            Console.WriteLine("--------------");
            RunTest();
            Console.WriteLine("--------------");
            RunTest();
            Console.WriteLine("--------------");
            RunTest();
            Console.WriteLine("--------------");
            RunTest();
            Console.WriteLine("--------------");
            RunTest();
            Console.WriteLine("--------------");
            RunTest();
        }

        private static void RunTest()
        {
            Console.WriteLine("By simple assignment");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));

            Console.WriteLine("By string builder");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));

            Console.WriteLine("By concate action");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));

        }

        private static string GetRandomString(int length)
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        private static void joining10000StringsByConcatAction()
        {
            string result = string.Empty;
            foreach (var item in _randomStrings)
            {
                result = string.Concat(result, item);
            }
        }

        private static void joining10000StringsByStringBuilderAction()
        {
            var sb = new StringBuilder();
            foreach (var item in _randomStrings)
            {
                sb.Append(item);
            }
            
            var resutl = sb.ToString();
        }

        private static void joining10000StringsBySimpleAssignmentAction()
        {
            string result = string.Empty;

            foreach (var item in _randomStrings)
            {
                result += item;
            }

        }
    }
}