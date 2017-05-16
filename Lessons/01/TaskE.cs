using System;
using System.Linq;
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
    public class TaskE {
        public static void Run() {
            //1
            Action<string> first = ((String x) => Console.WriteLine(x[0]));
            first("Dormammu, I've come to bargain!");

            //2
            Action<IEnumerable<int>> second = (array => {
                int indent = 0;

                foreach (int item in array) {
                    Console.WriteLine("{0}{1}", new String(' ', indent), item);
                    indent++;
                }
            });

            second(new int[] { 1, 2, 3, 4, 5 });

            //3
            Predicate<String> third = ((String x) => {
                if (!String.IsNullOrEmpty(x)) {
                    return Char.IsLetterOrDigit(x[0]);
                }

                return false;
            });

            String claim = "So Earth has wizards now, huh? ";
            Console.WriteLine("The first character of '{0}' is alphanumeric: {1}", claim, third(claim));

            claim = "[bursting in] Stop! Tampering with continuum probabilities is forbidden!";
            Console.WriteLine("The first character of '{0}' is alphanumeric: {1}", claim, third(claim));

            //4
            Action<string, string> fourth = ((firstString, theOtherOne) => {
                if (firstString.Length > theOtherOne.Length) {
                    Console.WriteLine(firstString);
                } else {
                    Console.WriteLine(theOtherOne);
                }
            });

            fourth("What's in that tea? Psilocybin? LSD? ", "It's just tea... with a little honey.");

            //5
            Func<DateTime, string> fifth = ((DateTime x) => { 
                return x.ToString("yyyyMMdd"); 
            });

            Console.WriteLine("Today is: {0}", fifth(DateTime.Today));

            //6
            Func<bool, bool, bool> sixth = ((firstBool, theOtherBool) => { 
                return firstBool ^ theOtherBool; 
            });

            Console.WriteLine("1==1 XOR 2==2 = {0}", sixth(1==1, 2==2));
            Console.WriteLine("1==10 XOR 2==2 = {0}", sixth(1==10, 2==2));

            //7
            Action seventh = () => { };

            //8
            Action<Action> eighth = ((x) => { 
                x(); 
            });

            eighth(seventh);
        }
    }
}