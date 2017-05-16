using System;
using System.Diagnostics.SymbolStore;
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

            //1./// (1) An anonymous method that prints the first char from input string to the console.
            Action<string> firstChar = inputString => { Console.WriteLine(inputString.Substring(0, 1)); };

            firstChar("Steve");

            /// (2) An anonymous method with an integer array as an input that prints all values to the console. 
            Action<int[]> printInts = ints =>
                {
                    //foreach (int x in ints)
                    //{
                    //    Console.WriteLine(x);
                    //}

                    for (int i = 0; i < ints.Length; i++)
                    {
                        string indent = new string(' ', i);
                        Console.WriteLine(indent + ints[i]);
                    }
                };

            printInts(new int[] { 4, 55, 34, 234, 666, 777 });

            /// (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
            Func<char, bool> letterOrDigit = (c) => char.IsNumber(c) || char.IsLetter(c);

            Console.WriteLine(letterOrDigit('s'));
            Console.WriteLine(letterOrDigit('='));

            /// (4) An anonymous method that prints longer string from a pair of strings to the console.
            Action<string, string> longestString = (s1, s2) =>
                {
                    Console.WriteLine(s1.Length > s2.Length ? s1 : s2);
                };

            longestString("steve", "Stephen");

            /// (5) An anonymous function that returns current date in "yyyymmdd" format.
            Func<DateTime, string> formatDate = (d) => $"{d:dd.MM.yyyy}";

            Console.WriteLine(formatDate(DateTime.Now));

            /// (6) An anonymous function that returns XOR result of two input boolean values.
            Func<bool, bool, bool> xorFunc = (bool1, bool2) => bool1 ^ bool2;

            Console.WriteLine(xorFunc(true, false));
            Console.WriteLine(xorFunc(true, true));
            Console.WriteLine(xorFunc(false, false));

            /// (7) An anonymous empty method.
            Action emptyAction = () => { };
            Console.WriteLine(emptyAction);
        }
    }
}