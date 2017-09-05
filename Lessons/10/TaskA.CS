using System;
using System.Text;

namespace Lessons._10
{
    class TaskA
    {
        public static void Run()
        {
            Console.WriteLine($"Simple assignment {Meter.Measure(joining10000StringsBySimpleAssignmentAction)}");
            Console.WriteLine($"String builder {Meter.Measure(joining10000StringsByStringBuilderAction)}");
            Console.WriteLine($"Concat action {Meter.Measure(joining10000StringsByConcatAction)}");
        }

        private static void joining10000StringsByConcatAction()
        {
            var result = string.Empty;

            for (int i = 0; i < 10000; i++)
            {
                result = string.Concat(result, "x");
            }
        }

        private static void joining10000StringsByStringBuilderAction()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 10000; i++)
            {
                builder.Append("x");
            }

            builder.ToString();
        }

        private static void joining10000StringsBySimpleAssignmentAction()
        {
            var result = string.Empty;

            for (int i = 0; i < 10000; i++)
            {
                result += "x";
            }
        }
    }
}