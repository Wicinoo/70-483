using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

            var input = Console.ReadLine();
            Action<string> printFirstChar = Console.WriteLine;
            printFirstChar(input);

            Action<int[]> printArray = x => Array.ForEach(x, Console.WriteLine);
            printArray(new[] { 5, 5, 6, 8, 4, 7, 53, 1, 14, -5, 0, 1 });

            Func<char, bool> isCharOrDigit = x => Char.IsLetterOrDigit(x);
            Console.WriteLine(isCharOrDigit('b') ? "b is a char or a digit" : "b is neither a char nor a digit");

            Action<string, string> printTheLongerOne = (x,y) => Console.WriteLine(x.Length > y.Length ? x : y);
            printTheLongerOne("I am the longer string", "IAmTheShortString");

            Func<string> getNow = () => DateTime.Now.ToString("yyyymmdd");
            Console.WriteLine(getNow());

            Func<bool, bool, bool> getXor = (x, y) => x != y;
            Console.WriteLine(getXor(true, false) ? "1 xor 0 is true" : "1 xor 0 is false");

            Action emptyMethod = () => { };
            emptyMethod();

            Action<Action> invokeAnAction = x => x();
            invokeAnAction(
                () =>
                    Console.WriteLine(
                        "I am parameterless and useless action, but as you see, even though I have been just invoked, this is wasting of resources and terrorism on our environment"));

        }
    }
}