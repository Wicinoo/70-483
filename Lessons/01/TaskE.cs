using System;
using System.Collections.Generic;

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
            Action<string> example = x => { Console.WriteLine(x[0]); };
            example("My name is what?");

            /****************************************************************/

            Action<IEnumerable<int>> arrDel = x => {
                int padding = 0;
                foreach (int item in x) {
                    Console.WriteLine(String.Format("{0}{1}", new String(' ', padding), item));
                    padding++;
                }
            };

            arrDel(new int[] { 1, 2, 3 });

            /****************************************************************/
            Predicate<string> isFirstCharacterAlphaNum = x => {
                if (!String.IsNullOrEmpty(x)) {
                    return System.Text.RegularExpressions.Regex.IsMatch(x, @"^[\w]");
                }
                return false;
            };

            string testString = "My name is who?";
            Console.WriteLine(String.Format("Is first character of '{0}' alphanumeric: {1}", testString, isFirstCharacterAlphaNum(testString)));

            testString = " My name is who?";
            Console.WriteLine(String.Format("Is first character of '{0}' alphanumeric: {1}", testString, isFirstCharacterAlphaNum(testString)));

            /****************************************************************/
            Action<string, string> printLongerString = (str1, str2) =>
            {
                if (str1.Length > str2.Length) {
                    Console.WriteLine(str1);
                }
                else {
                    Console.WriteLine(str2);
                }
            };


            printLongerString("My name is", "chka-chka Slim Shady");

            /****************************************************************/

            Func<string> formatDate = () => { return DateTime.Now.ToString("yyyyMMdd"); };

            Console.WriteLine(String.Format("Today in 'yyyymmdd' format: {0}", formatDate()));

            /****************************************************************/

            Func<bool, bool, bool> xor = (val1, val2) => { return val1 ^ val2; };

            Console.WriteLine(String.Format("XOR result for false, true is: {0}", xor(false, true)));
            Console.WriteLine(String.Format("XOR result for true, true is: {0}", xor(true, true)));

            /****************************************************************/

            Action meaningOfLife = () => { };

            /****************************************************************/

            Action<Action> actionInception = (x) => { x(); };

            actionInception(meaningOfLife);
        }
    }
}