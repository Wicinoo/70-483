using System;

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
            //1.
            Action<string> actionFirstChar = @string => Console.WriteLine(@string[0]);
            actionFirstChar("something");

            //2.
            Action<int[]> actionPrintInts = arr =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(new String(' ', i) + arr[i]);
                }
            };
            actionPrintInts(new int[] {5, 10, 7, 6, 9, 3, 4, 1});

            //3.
            Func<char, bool> CheckLetterOrNumber =
                (str) => ((str >= 'A' && str <= 'Z') || (str >= 'a' && str <= 'z') || (str >= '0' && str <= '9'));
            
            bool x = CheckLetterOrNumber('*');
            if (x)
            {
                Console.WriteLine("TRUE");
            }
            else
            {
                Console.WriteLine("FALSE");
            }

            //4.
            Action<string, string> PrintLongString = (a, y) => Console.WriteLine(a + y);
            PrintLongString("aaaad", "bbbbn");

            //6.
            Func<bool, bool, bool> GetXor = (a, b) => (a != b);
            bool res = GetXor(true, false);
            if (res)
            {
                Console.WriteLine("XOR");
            }
            else
            {
                Console.WriteLine("NOT XOR");
            }

            //7.
            Action blabla = () => { };


            //8.
            Action<Action> ActionInAction = (ac) => { ac.Invoke(); };

            //throw new NotImplementedException();
        }
    }
}