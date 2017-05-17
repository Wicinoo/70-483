using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lessons._01
{
    public class TaskE
    {
        public static void Run()
        {
            /// <summary>
            /// Use the most suitable system delegates (Action, Func, Predicate) for the problems below. 
            /// For each case write an example and print results for functions.
            /// ---
            /// (1) An anonymous method that prints the first char from input string to the console.

            Action<string> printfirst = @string => Console.WriteLine(@string[0]);
            printfirst("asdada");

            /// (2) An anonymous method with an integer array as an input that prints all values to the console. 
            /// Each value is preceded by the number of spaces according to the position of the item.
            /// "(itemAtPosition0)"
            /// " (itemAtPosition1)"
            /// "  (itemAtPosition2)"
            /// ...
            Action<int[]> printItems = (i) =>
            {
                string indentation = string.Empty;
                (new List<int>(i)).ForEach(itm => { Console.WriteLine(indentation + "{0}",itm); indentation += " "; });
            };

            printItems(new int[] { 12, 10, 2 });

            /// (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
            Func<Char,Boolean> isCharacter = (c) => {
                return Regex.Match(c.ToString(), @"([A-Za-z0-9])", RegexOptions.IgnoreCase).Success;
            };

            Console.WriteLine("Character @ {0}", isCharacter('@'));
            Console.WriteLine("Character 7 {0}", isCharacter('7'));

            /// (4) An anonymous method that prints longer string from a pair of strings to the console.
            Action<string, string> printLonger = (s1, s2) => Console.WriteLine(s1.Length > s2.Length ? s1 : s2);
            printLonger("short", "Very very very long");

            /// (5) An anonymous function that returns current date in "yyyymmdd" format.
            Func<string> currentDate = () => DateTime.Now.ToString("yyyyMMdd");
            Console.WriteLine(currentDate());

            /// (6) An anonymous function that returns XOR result of two input boolean values.
            Func<Boolean, Boolean, Boolean> xor = (b1, b2) => b1^b2;

            Console.WriteLine("true xor true is " + xor(true, true));
            Console.WriteLine("true xor false is " + xor(true, false));
            Console.WriteLine("false xor true is " + xor(false, true));
            Console.WriteLine("false xor false is " + xor(false, false));

            /// (7) An anonymous empty method.
            Action empty = () => { Console.WriteLine("This is doing nothing."); };

            /// (8) An anonymous method that gets apr parameterless action as an input and invokes that action.
            Action<Action> doSomethingImposible = doNothing => { doNothing(); };

            doSomethingImposible(empty);

        }
    }
}