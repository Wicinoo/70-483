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
            // E.g. Action<DateTime> problem42 = dt => { Console.WriteLine(dt...)};

            Action<string> problem1 = @string => Console.WriteLine($"{ @string[0] }");
            problem1("hello, world");

            Action<int[]> problem2 = numberCollection =>
            {
                string space = "";

                foreach (var number in numberCollection)
                {
                    Console.WriteLine(space + $"{number}");
                    space += " ";
                }
            };

            problem2(new int[] { 1, 2, 3, 4, 5 });

            Predicate<char> problem3 = @char => { return Char.IsLetterOrDigit(@char); };
            Console.WriteLine($"char is letter or digit (digit): {problem3('1')}");
            Console.WriteLine($"char is letter or digit (letter): {problem3('a')}");

            Action<string, string> problem4 = (@string1, @string2) =>
            {
                var longerString = @string1.Length > @string2.Length ? @string1 : @string2;

                Console.WriteLine($"the longest string out of {@string1} and {@string2} is {longerString}");
            };

            problem4("hello", "world!");
            problem4("longest", "string");

            Func<DateTime, string> problem5 = date => date.ToString("yyyy/mm/dd");
            Console.WriteLine($"Current date is: {problem5(DateTime.Now)}");

            Func<bool, bool, bool> problem6 = (x, y) => { return (x && !y) || (!x && y); };
            Console.WriteLine($"Result of XOR operation with 1st param = true, 2nd param = false is: {problem6(true, false)}");
            Console.WriteLine($"Result of XOR operation with 1st param = false, 2nd param = true is: {problem6(false, true)}");
            Console.WriteLine($"Result of XOR operation with 1st param = true, 2nd param = true is: {problem6(true, true)}");
            Console.WriteLine($"Result of XOR operation with 1st param = false, 2nd param = false is: {problem6(false, false)}");

            Action problem7 = () => { };

            Action<Action> problem8 = (action) => { action(); };
            Action problem8Parameter = () => { Console.WriteLine("Calling parameterless action..."); };

            problem8(problem7);
            problem8(problem8Parameter);
        }
    }
}