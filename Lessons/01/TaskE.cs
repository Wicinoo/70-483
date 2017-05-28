using System;
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
            Action<string> part1 = input => { Console.WriteLine(input?[0]); };

            Action<int[]> part2 =
                input => input
                .Select((value, index) => new { value, index })
                .ToList()
                .ForEach(x => Console.WriteLine($"{new string(' ', x.index)}{x.value}"));

            Predicate<char> part3 = input => char.IsLetterOrDigit(input);

            Func<string, string, string> part4 = (input1, input2) => input1.Length > input2.Length ? input1 : input2;

            Action part5 = () => Console.WriteLine($"{DateTime.Now:yyyymmdd}");

            Func<bool, bool, bool> part6 = (input1, input2) => input1 ^ input2;

            Action part7 = delegate { };

            Action<Action> part8 = currentTime => currentTime();


            part1("Hello");
            part2(new int[] { 1, 5, 8 });
            Console.WriteLine(part3('1'));
            Console.WriteLine(part4("Hello", "Ahoj"));
            part5();
            Console.WriteLine(part6(true, false));
            part7();
            part8(part5);
        }
    }
}