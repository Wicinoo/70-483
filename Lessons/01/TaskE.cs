using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using FluentAssertions.Primitives;

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
            Console.WriteLine();
            AnswerOne();
            Console.WriteLine();
            AnswerTwo();
            Console.WriteLine();
            AnswerThree();
            Console.WriteLine();
            AnswerFour();
            Console.WriteLine();
            AnswerFive();
            Console.WriteLine();
            AnswerSix();
            Console.WriteLine();
            AnswerSeven();
            Console.WriteLine();
            AnswerEight();
        }

        private static void AnswerOne()
        {
            Action<string> getFirstChar = (x) => Console.WriteLine(x[0]);

            getFirstChar("first");
        }

        private static void AnswerTwo()
        {
            Action<List<int>> printObjectsInArray = (list) => list.ForEach(
                num => GetLineForIntList(num, list.IndexOf(num)));

            var intList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
            printObjectsInArray(intList);
        }

        private static void GetLineForIntList(int num, int index)
        {
            var spaces = new String(' ', index);;
            Console.WriteLine(spaces + num);
        }

        private static void AnswerThree()
        {
            /// (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
            Predicate<char> isCharOrInt = Char.IsLetterOrDigit;
            Console.WriteLine(isCharOrInt('e'));
            Console.WriteLine(isCharOrInt('3'));
            Console.WriteLine(isCharOrInt('*'));
        }

        private static void AnswerFour()
        {
            //(4) An anonymous method that prints longer string from a pair of strings to the console.
            Action<string, string> printLongerString = (a, b) =>
            {
                var longerString = a.Length > b.Length ? a : b;

                Console.WriteLine(longerString);
            };

            printLongerString("pickMe", "notMe");
            printLongerString("notMe", "pickMe");
        }
        private static void AnswerFive()
        {
            //(5) An anonymous function that returns current date in "yyyymmdd" format.
            Func<DateTime, string> getDateTimeString = dateTime => dateTime.ToString("yyyyMMdd");
            var dateString = getDateTimeString(DateTime.Now);

            Console.WriteLine(dateString);
        }

        private static void AnswerSix()
        {
            /// (6) An anonymous function that returns XOR result of two input boolean values.
            Func<bool, bool, bool> xorPredicate = (a, b) => a != b;
            Console.WriteLine(xorPredicate(true, true));
            Console.WriteLine(xorPredicate(true, false));
            Console.WriteLine(xorPredicate(false, true));
            Console.WriteLine(xorPredicate(false, false));
        }

        private static void AnswerSeven()
        {
            /// (7) An anonymous empty method.
            Action nothing = () => { };

            Console.WriteLine(nothing);
        }

        private static void AnswerEight()
        {
            /// (8) An anonymous method that gets apr parameterless action as an input and invokes that action.
            Action function = () => Console.WriteLine("I've been invoked");

            Action<Action> invoker = (func) => func();

            invoker(function);
        }
    }
}