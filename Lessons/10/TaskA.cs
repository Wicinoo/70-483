using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    static class DurationMeasurer
    {
        public static TimeSpan Measure(Action actionToMeasure)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            actionToMeasure();

            sw.Stop();

            return sw.Elapsed;
        }
    }

    public class TaskA
    {
        public const string stringA = "ASDKLJKLJVM?NXDFS";

        public TaskA()
        {
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }

        void joining10000StringsBySimpleAssignmentAction()
        {
            var temp = stringA;

            for(int i = 0; i < 10000; i++)
            {
                temp += "x";
            }
        }

        void joining10000StringsByStringBuilderAction()
        {
            var sb = new StringBuilder(stringA);

            for (int i = 0; i < 10000; i++)
            {
                sb.Append("x");
            }
        }

        void joining10000StringsByConcatAction()
        {
            var temp = stringA;

            for (int i = 0; i < 10000; i++)
            {
                temp = string.Concat(temp, "x");
            }
        }
    }
}
