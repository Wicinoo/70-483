using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
            //(1) An anonymous method that prints the first char from input string to the console.

            Action<string> problem1 = someString =>
            {
                if (!string.IsNullOrEmpty(someString))
                {
                    Console.WriteLine(someString[0]);
                }
            };

            // (2) An anonymous method with an integer array as an input that prints all values to the console. 

            Action<int[]> problem2 = someIntArray => {
                                                         if (someIntArray != null && someIntArray.Length > 0)
                                                         {
                                                             for (int i = 0; i < someIntArray.Length - 1; i++)
                                                             {
                                                                 Console.WriteLine(new string(' ', i) + someIntArray[i].ToString());
                                                             }
                                                         }
                                                     };

            // (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
            Predicate<char> problem3 = char.IsLetterOrDigit;

            // (4) An anonymous method that prints longer string from a pair of strings to the console.
            Action<string, string> problem4 = (str1, str2) =>
            {
                var toPrint = string.IsNullOrEmpty(str1) ? string.Empty : str1;

                toPrint = string.IsNullOrEmpty(str2) ? toPrint : str2.Length > toPrint.Length ? str2 : toPrint;

                Console.WriteLine(toPrint);
            };

            // (5) An anonymous function that returns current date in "yyyymmdd" format.
            Func<string> problem5 = () => DateTime.Now.ToString("yyyyMMdd");

            // (6) An anonymous function that returns XOR result of two input boolean values.
            Func<bool, bool, bool> problem6 = (bool1, bool2) => bool1 ^ bool2;

            // (7) An anonymous empty method.
            Action problem7 = () => { };

            // (8) An anonymous method that gets apr parameterless action as an input and invokes that action.
            Action<Action> problem8 = actionForAction => actionForAction();

        }
    }
}