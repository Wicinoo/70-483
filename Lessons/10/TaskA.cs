using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskA
    {
        public static void Run()
        {
            const int count = 10000;

            Action joining10000StringsBySimpleAssignmentAction = () =>
            {
                string result = string.Empty;

                for (int i = 0; i < count; i++)
                {
                    result += "x";
                }

                Console.WriteLine("joining10000StringsBySimpleAssignmentAction");
            };

            Action joining10000StringsByStringBuilderAction = () =>
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    sb.Append("x");
                }

                Console.WriteLine("joining10000StringsByStringBuilderAction");
            };

            Action joining10000StringsByConcatAction = () =>
            {
                string result = string.Empty;

                for (int i = 0; i < count; i++)
                {
                    result = string.Concat(result, "x");
                }

                Console.WriteLine("joining10000StringsByStringBuilderAction");
            };

            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }
    }

    public static class DurationMeasurer
    {
        public static TimeSpan Measure(Action actionToMeasure)
        {
            DateTime start = DateTime.Now;
            actionToMeasure();
            return DateTime.Now - start;
        }
    }
}
