using System;

namespace Lessons._01
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions.Primitives;

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

            Action<string> p1 = x => Console.WriteLine(x[0]);

            Action<int[]> p2 = x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        Console.WriteLine("{0} ({1})", new String(' ', i), x[i].ToString());
                    }
                };

            Predicate<char> p3 = x => Char.IsLetterOrDigit(x);

            Action<string, string> p4 = (x, y) =>
                {
                    if (x.Length >= y.Length) Console.WriteLine(x);
                    else Console.WriteLine(y);
                };

            Func<string> p5 = () =>
                {
                    var dt = DateTime.Now;
                    return dt.ToString("yyyyMMdd");
                };

            Func<bool, bool, bool> p6 = (a, b) =>
                {
                    return a != b;
                };

            Action p7 = () => { };

            Action<Action> p8 = x => { x(); };



            p1("hullo");

            p2(new int[] {1, 2, 3, 4});

            Console.WriteLine(p3('L').ToString());

            p4("blablo", "dolgates");

            Console.WriteLine(p5());

            Console.WriteLine(p6(true, false).ToString());

            p7();

            p8(p7);
        }
    }
}