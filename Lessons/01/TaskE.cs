using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
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
            Action<string> problem1 = someString => { Console.WriteLine(someString[0]); };
            Action<int[]> problem2 = array =>
            {
                foreach (var t in array)
                {
                    Console.WriteLine(t.ToString().PadLeft(t, ' '));
                }
            };
            Predicate<char> problem3 = char.IsLetterOrDigit;
            Action<string, string> problem4 = (first, second) => { Console.WriteLine(first + second); };
            Func<string> problem5 = () => DateTime.Now.ToString("yyyyMMdd");
            Func<bool, bool, bool> problem6 = (a, b) => (a || b) && !(a && b);
            Action problem7 = () => { };
            Action<Action> problem8 = action => action.Invoke();
            
            problem1("sadsaadd");
            problem2(new [] { 1, 2, 3, 4, 5 });
            Console.WriteLine(problem3('q'));
            problem4("first", "second");
            Console.WriteLine(problem5());
            Console.WriteLine(problem6(true, false));
            problem7();
            problem8(() => Console.WriteLine("sdad"));
        }
    }
}