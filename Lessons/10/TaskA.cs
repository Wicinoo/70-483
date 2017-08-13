using System;
using System.Text;

namespace Lessons._10
{
    public class TaskA
    {
        public static void Run()
        {
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }



        private static void joining10000StringsBySimpleAssignmentAction()
        {
            var result = string.Empty;

            for (int i = 0; i < 10000; i++)
            {
                result += "x";
            }
        }

        private static void joining10000StringsByStringBuilderAction()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 10000; i++)
            {
                sb.Append("x");
            }
        }

        private static void joining10000StringsByConcatAction()
        {
            var result = string.Empty;

            for (int i = 0; i < 10000; i++)
            {
                result = string.Concat(result, "x");
            }
        }
    }

    public static class DurationMeasurer
    {
        public static TimeSpan Measure(Action actionToMeasure)
        {
            var start = DateTime.Now;
            actionToMeasure.Invoke();
            var stop = DateTime.Now;
            return stop - start;
        }
    }


}