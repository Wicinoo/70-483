using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

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
            #region HelperMethods

            Func<int, char, string> filler = (number, character) =>
            {
                StringBuilder emptyString = new StringBuilder(string.Empty);

                for (int i = 0; i < number; i++)
                {
                    emptyString.Append(character);
                }

                return emptyString.ToString();
            };

            #endregion

            Action<string> firstChar = inputString => Console.WriteLine(inputString[0]);

            Action<int[]> treePrinter = intArray =>
            {
                foreach (var number in intArray)
                {
                    Console.WriteLine(filler(number, ' ') + number);
                }
            };

            Predicate<char> isLetterOrDigit = char.IsLetterOrDigit;

            Action<string, string> joinAndPrint = (firstString, secondString) =>
            {
                Console.WriteLine($"{firstString}{secondString}");
            };

            Func<string> formatDate = () => DateTime.Now.ToString("yyyyMMdd");

            //not X and Y, or X and not Y. X and Y and not X and not Y are eliminated
            Func<bool, bool, bool> xor = (firstStatement, secondStatement) => ((!firstStatement) && secondStatement) || (firstStatement && (!secondStatement));

            Action doNothing = () => { };

            Action<Action> invokeAction = action => action.BeginInvoke(EndInvoke, null);

            firstChar("Hello, world!");
            treePrinter(new[] { 1,2,3,4,5,6 });
            Console.WriteLine(isLetterOrDigit('*'));
            joinAndPrint("Foo,", "Bar!");
            Console.WriteLine(formatDate());
            Console.WriteLine(xor(false, true));

            BeginInvoke();
            invokeAction(doNothing);
            InvocationInProgress();
        }

        private static void BeginInvoke() => Console.WriteLine("Invocation has begun. All hail Cthulhu.");
        private static void InvocationInProgress() => Console.WriteLine("Chanters are sitting in a circle uttering words long forgotten...");
        private static void EndInvoke(IAsyncResult result) => Console.WriteLine("Cthulhu has been summoned to this world. All will be dead.");
    }
}