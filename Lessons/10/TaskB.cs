using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public class TaskB
    {
        private static Random _seededRandom;
        private static Random SeededRandom
        {
            get
            {
                _seededRandom = _seededRandom ?? new Random(Guid.NewGuid().GetHashCode());
                return _seededRandom;
            }
        }

        public static void Run()
        {
            const int count = 100000;
            const int stringLength = 10;

            Console.WriteLine("Random strings generating ...");

            var randomStrings = Enumerable.Range(1, count).Select(_ => GetRandomString(stringLength)).ToList();

            Console.WriteLine("Random strings generated.");

            Action joiningRandomStringsBySimpleAssignmentAction = () =>
            {
                string result = string.Empty;

                for (int i = 0; i < randomStrings.Count; i++)
                {
                    result += randomStrings[i];
                }

                Console.WriteLine("joiningRandomStringsBySimpleAssignmentAction");
            };

            Action joiningRandomStringsByStringBuilderAction = () =>
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < randomStrings.Count; i++)
                {
                    sb.Append(randomStrings[i]);
                }

                Console.WriteLine("joiningRandomStringsByStringBuilderAction");
            };

            Action joiningRandomStringsByConcatAction = () =>
            {
                string result = string.Empty;

                for (int i = 0; i < randomStrings.Count; i++)
                {
                    result = string.Concat(result, randomStrings[i]);
                }

                Console.WriteLine("joiningRandomStringsByStringBuilderAction");
            };

            Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsBySimpleAssignmentAction));
            Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsByStringBuilderAction));
            Console.WriteLine(DurationMeasurer.Measure(joiningRandomStringsByConcatAction));
        }

        public static string GetRandomString(int length)
        {
            return new string(Enumerable.Range(0, length).Select(x => (char)SeededRandom.Next('a', 'z')).ToArray());
        }
    }

}
