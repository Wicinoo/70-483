using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;

namespace Lessons._10
{
    public class TaskAB
    {
        public static void Run()
        {
            Console.WriteLine(DurationMeasurer.Measure(StringConcater.Joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(StringConcater.Joining10000StringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(StringConcater.Joining10000StringsByConcatAction));

            Console.WriteLine(DurationMeasurer.Measure(StringConcater.JoiningRandomStringsBySimpleAssignment));
            Console.WriteLine(DurationMeasurer.Measure(StringConcater.JoiningRandomStringsByStringBuilder));
            Console.WriteLine(DurationMeasurer.Measure(StringConcater.JoiningRandomStringsByConcat));
        }
    }

    public class DurationMeasurer
    {
        public static TimeSpan  Measure(Action actionToMeasure)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            actionToMeasure();
            clock.Stop();
            return clock.Elapsed;
        }
    }

    public class StringConcater
    {
        public static void Joining10000StringsBySimpleAssignmentAction()
        {
            var range = Enumerable.Range(1, 10000);
            var result = string.Empty;
            range.ForEach(x => result += "x"); 
        }

        public static void Joining10000StringsByStringBuilderAction()
        {
            var range = Enumerable.Range(1, 10000);
            var sb = new StringBuilder();
            range.ForEach(x => sb.Append("x"));
        }

        public static void JoiningRandomStringsBySimpleAssignment()
        {
            var range = Enumerable.Range(1, 10000);
            var result = string.Empty;
            range.ForEach(x => result = string.Concat(result, "x"));
        }

        public static void JoiningRandomStringsByStringBuilder()
        {
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();
            var result = string.Empty;
            randomStrings.ForEach(x => result += x);
        }

        public static void JoiningRandomStringsByConcat()
        {
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();
            var sb = new StringBuilder();
            randomStrings.ForEach(x => sb.Append(x));
        }

        public static void Joining10000StringsByConcatAction()
        {
            var randomStrings = Enumerable.Range(1, 1000).Select(_ => GetRandomString(10)).ToList();
            var result = string.Empty;
            randomStrings.ForEach(x => result = string.Concat(result, x));
        }

        static string GetRandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[rand.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }
}
