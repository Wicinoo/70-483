using System;
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

            // E.g. Action<DateTime> problem42 = dt => { Console.WriteLine(dt...)};

            Action<String> problem1 = input => { Console.WriteLine(input[0]); };
            problem1("ABCD");
            Action<int[]> problem2 = input =>
            {
                for (int i = 0; i < input.Length; i++)
                {
                    Console.WriteLine("{0}({1})", new string(' ', i), input[i]);
                }
            };

            problem2(new[] { 1, 2, 3, 4, 5 });


            Func<char, bool> problem3 = input =>
             {
                 var template = new Regex("[a-zA-z0-9]");
                 return template.IsMatch(input.ToString());
             };
            Console.WriteLine("a is {0}", problem3('a'));
            Console.WriteLine("< is {0}", problem3('<'));
            
            Action<string, string> problem4 = (input1, input2) =>
            {
                Console.WriteLine("{0}", (input1.Length > input2.Length ? input1 : input2));
            };
            Console.WriteLine("from 'asdf' and 'asdfg'. Longer is:");
            problem4("asdf", "asdfg");

            Func<string> problem5 = () => $"{DateTime.Now:yyyymmdd}";
            Console.WriteLine($"Current date: {problem5()}");

            Func<bool, bool, bool> problem6 = (input1, input2) => input1 ^ input2;
            Console.WriteLine($"True XOR True = {problem6(true, true)}");
            Console.WriteLine($"True XOR False = {problem6(true, false)}");
            Console.WriteLine($"false XOR False = {problem6(false, false)}");

            Action problem7 = () => { };
            problem7();

            Action<Action> problem8 = input => input();
            problem8(() => Console.WriteLine("test"));
            throw new NotImplementedException();
        }
    }
}

