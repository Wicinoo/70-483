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
            // E.g. Action<DateTime> problem42 = dt => { Console.WriteLine(dt...)};
            Action<string> printFirst = toPrint => Console.WriteLine(toPrint.Substring(0, 1));

            Action<int[]> printAll = toPrint =>
            {
                foreach (var item in toPrint.Select((value, i) => new { Value = value, Index = i }))
                {
                    Console.WriteLine($"{new string(' ', item.Index)}{item.Value}");
                }
            };

            Predicate<char> isLetterOrDigit = character => char.IsLetterOrDigit(character);

            Action<string, string> printLoneger = (first, second) => Console.WriteLine(first.Length > second.Length ? first : second);

            Func<DateTime, string> convertToFormat = dateTime => dateTime.ToString("yyyyMMdd");

            Func<bool, bool, bool> xor = (a, b) => (a || b) && (!a || !b);

            Action empty = () => { };

            Action<Action> executeAction = action => action?.Invoke();
        }
    }
}