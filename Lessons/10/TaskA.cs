//A.Create a static class with a method
//TimeSpan Measure(Action actionToMeasure);
//It will return a duration of an action as the TimeSpan value.

//Create actions/methods defined below and use the Measure method:
//- joining 10 000 strings by using "+=" operator (result += "x").
//- joining 10 000 strings by using StringBuilder (sb.Append("x")).
//- joining 10 000 strings by using string.Concat(result = string.Concat(result, "x")). 

//Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));
//Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));
//Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction)); 

//Compare performance of all approaches.How many times are they slower than the fastest one?


using System;
using System.Text;

namespace Lessons._10
{
    class TaskA
    {
        const int Iterations = 10000;
        public static void Run()
        {
            Console.WriteLine("By simple assignment");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsBySimpleAssignmentAction));

            Console.WriteLine("By string builder");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByStringBuilderAction));

            Console.WriteLine("By concate action");
            Console.WriteLine(DurationMeasurer.Measure(joining10000StringsByConcatAction));
        }

        private static void joining10000StringsByConcatAction()
        {
            string result = string.Empty;
            for (int i = 0; i < Iterations; i++)
            {
                result = string.Concat(result, "x");
            }
            
        }

        private static void joining10000StringsByStringBuilderAction()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append("x");
            }
            var resutl = sb.ToString();
            
        }

        private static void joining10000StringsBySimpleAssignmentAction()
        {
            string result = string.Empty;
            for (int i = 0; i < Iterations; i++)
            {
                result += "x";
            }
        }
    }
}