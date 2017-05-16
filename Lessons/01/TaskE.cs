using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            // 1

            Action<string> f1 = (s) =>
            {
                Console.Out.WriteLine(s[0]);
            };

            f1("Test");

            // 2

            Action<int[]> f2 = (ia) =>
            {
                Console.Out.WriteLine(
                    string.Join(
                        "\n",
                        ia.Select(PrefixWithSpaces)
                    )
                );
            };

            f2(new[] {3, 6, 9, 12, 15});

            // 3

            Func<char, bool> f3 = char.IsLetterOrDigit;

            Console.Out.WriteLine($"Is 'A' {(f3('A') ? "is" : "is not")} a letter or a digit.");

            // 4

            Action<string, string> f4 = (s1, s2) => { Console.Out.WriteLine(s1.Length >= s2.Length ? s1 : s2); };

            f4("short_string", "looooooooooong_string");

            // 5

            Func<string> f5 = () => DateTime.Now.ToString("yyyymmdd");

            Console.Out.WriteLine(f5());

            // 6

            Func<bool, bool, bool> f6 = (b1, b2) => b1 ^ b2;

            Console.Out.WriteLine(f6(true, true));


            // 7

            Action f7 = () => {};

            f7();

            // 8

            Action<Action> f8 = a => a();

            f8(() => { Console.Out.WriteLine("Hi!"); });
        }

        public static string PrefixWithSpaces(int value, int nSpaces)
        {
            return string.Join("", Enumerable.Repeat(" ", nSpaces)) + value;
        }
    }
}