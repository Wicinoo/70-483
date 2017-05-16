using System;
using System.Text;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string StringTransformer(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public delegate string StringTransformer(string stringToTransform);

        public static void Run()
        {
            StringTransformer Reverse = delegate (string stringToTransform)
            {
                var charArray = stringToTransform.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            };


            StringTransformer ShiftLeft = (string stringToTransform) =>
            {
                return stringToTransform.Substring(1, stringToTransform.Length - 1) + stringToTransform.Substring(0, 1);
            };

            StringTransformer ShiftRight = (string stringToTransform) =>
            {
                return stringToTransform.Substring(stringToTransform.Length - 1, 1) + stringToTransform.Substring(0, stringToTransform.Length - 1);
            };

            StringTransformer Mask = (x) => { return new String('*', x.Length); };

            StringTransformer FunnyStuff = x => new StringBuilder(x.Length * x.Length).Insert(0, x, x.Length).ToString();

            Console.WriteLine(Reverse("potatoes"));

            Console.WriteLine(ShiftLeft("I LIKE TRAINS"));

            Console.WriteLine(ShiftRight("THIS SENTENCE CONTAINS FIVE WORDS"));

            Console.WriteLine(FunnyStuff("Merhaba"));
        }
    }
}