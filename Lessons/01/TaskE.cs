using System;
using System.Linq;

namespace Lessons._01
{
    /// <summary>
    /// Use the most suitable system delegates (Action, Func, Predicate) for the problems below. 
    /// For each case write an example and print results for functions.
    /// ---
    /// (1) An anonymous method that prints the first char from input string to the console.
    /// (2) An anonymous method with an integer array as an input that prints all values to the console. 
    /// Each value is preceded by the number of spaces according to the position of the item.
    /// "(itemAtPosition0)"
    /// " (itemAtPosition1)"
    /// "  (itemAtPosition2)"
    /// ...
    /// (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
    /// (4) An anonymous method that prints longer string from a pair of strings to the console.
    /// (5) An anonymous function that returns current date in "yyyymmdd" format.
    /// (6) An anonymous function that returns XOR result of two input boolean values.
    /// (7) An anonymous empty method.
    /// (8) An anonymous method that gets apr parameterless action as an input and invokes that action.
    /// </summary>
    public class TaskE
    {
        public static void Run()
        {
            PrintFirstChar();

            Console.WriteLine("=========");

            PrintIntArray();

            Console.WriteLine("=========");

            TrueForLetterOrDigit();

            Console.WriteLine("=========");

            PrintLongerString();

            Console.WriteLine("=========");

            ReturnDate();

            Console.WriteLine("=========");

            Xor();

            Console.WriteLine("=========");

            EmptyMethod();

            Console.WriteLine("=========");

            InvokeActionInMethod();
        }

        private static void InvokeActionInMethod()
        {
            Action action = () => Console.WriteLine("text in anon");

            Action<Action> m8 = act => act();

            m8(action);
        }

        private static void EmptyMethod()
        {
            Action m7 = () => { };
        }

        private static void Xor()
        {
            Func<bool, bool, bool> m6 = (b1, b2) => b1 ^ b2;

            Console.WriteLine(m6(false, false));
            Console.WriteLine(m6(false, true));
            Console.WriteLine(m6(true, false));
            Console.WriteLine(m6(true, true));
        }

        private static void ReturnDate()
        {
            Func<string> m5 = () => DateTime.Today.ToString("yyyyMMdd");

            Console.WriteLine(m5());
        }

        private static void PrintLongerString()
        {
            Action<string, string> m4 = (s1, s2) =>
            {
                if (s1.Length > s2.Length)
                    Console.WriteLine(s1);
                else
                    Console.WriteLine(s2);
            };

            m4("foo", "foobar");
        }

        private static void TrueForLetterOrDigit()
        {
            Predicate<char> m3 = c => char.IsLetterOrDigit(c);

            Console.WriteLine(m3('a'));
            Console.WriteLine(m3('#'));
        }

        private static void PrintFirstChar()
        {
            Action<string> m1 = s => Console.WriteLine(s.FirstOrDefault());
            m1("abc");
        }

        private static void PrintIntArray()
        {
            Action<int[]> m2 = array =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var strNumber = array[i].ToString();
                    Console.WriteLine(strNumber.PadLeft(strNumber.Length + i, ' '));
                }
            };

            m2(new int[] { 10, 20, 30 });
        }
    }
}