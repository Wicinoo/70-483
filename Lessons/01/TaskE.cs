using System;

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
        public delegate void PrintString(string stringToPrint);

        public delegate void PrintIntegerArray(int[] intArrayToPrint);

        public delegate void DoSomething(Action action);

        public static void Run()
        {
            Action<string> firstCharacter = s => Console.WriteLine(s[0]);

            firstCharacter("V for Vendetta");

            Action<int[]> printArray = print =>
            {
                for (var p = 0; p < print.Length; p++)
                {
                    Console.Write(new string(' ', p));
                    Console.Write(p);
                    Console.WriteLine();
                }
            };

            printArray(new[] { 1, 2, 3, 4, 5 });

            Predicate<char> IsLetterOrDigit = char.IsLetterOrDigit;

            Console.WriteLine(IsLetterOrDigit('{'));
            Console.WriteLine(IsLetterOrDigit('3'));

            Action<string, string> WriteTwoStrings = (s, s1) => Console.WriteLine("{0} {1}", s, s1);

            WriteTwoStrings("Hello", "World");

            Func<DateTime, string> FancyDateFormat = time => time.ToString("yyyymmdd");

            Console.WriteLine(FancyDateFormat(DateTime.Now));

            Func<bool, bool, bool> XorTwoBooleams = (b, b1) => b ^ b1;

            Console.WriteLine("Xor of false and tru {0}", XorTwoBooleams(false, true));

            Action Nothing = () => { };

            Nothing();

            DoSomething DoNothing = action => action.Invoke();
        }
    }
}