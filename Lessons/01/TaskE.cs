using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

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

            Action<string> printFirstChar = s => Console.WriteLine(s[0]);
            printFirstChar.Invoke("First char");

            Action<int[]> printArray = ints =>
            {
                var arrayLength = ints.Length;

                for (var i = 0; i < arrayLength; i++)
                {
                    Console.WriteLine("{0}{1}", new string(' ', i), ints[i]);
                }
            };

            printArray.Invoke(new int[] { 1, 2, 15, 150, 366, 11});

            Predicate<char> isDigitOrLetter = c => char.IsDigit(c) || char.IsLetter(c);

            var isDigitOrLetterResult = isDigitOrLetter.Invoke(Environment.NewLine[0]);
            Console.WriteLine(isDigitOrLetterResult);

            Action<string, string> printLongerString = (s1, s2) =>
            {
                var stringToWrite = (s1?.Length ?? 0) >= (s2?.Length ?? 0) ? s1 : s2;
                Console.WriteLine(stringToWrite);
            };

            printLongerString.Invoke("Quess which of these two strings", "is longer just by looking at them.");

            Func<DateTime, string> toMyFormat = dt => dt.ToString("yyyyMMdd");

            var today = toMyFormat.Invoke(DateTime.Today);

            Console.WriteLine(today);

            Func<bool, bool, bool> xor = (b1, b2) => b1 ^ b2;

            var xorResult = xor.Invoke(true, false);

            Console.WriteLine(xorResult);

            Action emptyAction = () => { };

            Action<Action> coolAction = a => a.Invoke();

            coolAction.Invoke(emptyAction);
        }
    }
}