using System;
using System.Diagnostics;
using System.Text;

namespace Lessons._10
{
    internal class TaskA
    {
        public static void Run()
        {
            var iterations = 10000;

            Action joining10000StringsBySimpleAssignmentAction = () =>
                {
                    var result = string.Empty;
                    for (int i = 0; i < iterations; i++)
                    {
                        result += "x";
                    }
                };

            Action joining10000StringsByStringBuilderAction = () =>
                {
                    var sB = new StringBuilder();
                    for (int i = 0; i < iterations; i++)
                    {
                        sB.Append("x");
                    }
                };

            Action joining10000StringsByConcatAction = () =>
                {
                    var result = string.Empty;
                    for (int i = 0; i < iterations; i++)
                    {
                        result = string.Concat(result, "x");
                    }
                };

            Console.WriteLine("+=");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine("StringBuilder");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
            Console.WriteLine("Concat");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }
    }

    internal static class DurationMeasurer
    {
        public static TimeSpan Measure(Action actionToMeasure)
        {
            var stopWatch = Stopwatch.StartNew();
            actionToMeasure();
            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}