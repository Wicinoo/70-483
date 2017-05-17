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
        public static void Run()
        {
            Action<string> firstChar = x => Console.WriteLine(x[0]);
            Action<int[]> printList = x =>
            {
                string spaces = String.Empty;
                foreach (var item in x)
                {
                    Console.WriteLine(spaces + item.ToString() + Environment.NewLine);
                    spaces += " ";
                }
            };

            Predicate<char> isDigitOrLetter = x => char.IsLetterOrDigit(x);
            Action<string, string> printLonger = (x,y) => Console.WriteLine(x.Length > y.Length ? x : y);
            Func<DateTime, string> formatDateTime = x => x.ToString("yyyymmdd");
            Func<bool, bool, bool> xor = (x, y) => x ^ y;
            Action ac = () => { };
            Action<Action> action = x => x();

            //test
        }
    }
}