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
            // (1)
            Action<string> result1 = input => Console.WriteLine(input[0]);
            result1("Foo");

            // (2)
            Action<int[]> result2 = input =>
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        var str = input[i].ToString();

                        // Insert relevant number of spaces and print result value
                        Console.WriteLine(str.PadLeft(i + str.Length));
                    }
                };
            result2(new[] { 1, 5, 77, 323 });

            // (3)
            Func<char, bool> result3 = c => Char.IsLetter(c) || Char.IsDigit(c);
            Console.WriteLine($"Result 3 for 'Y': {result3('Y')}");
            Console.WriteLine($"Result 3 for '£': {result3('£')}");

            // (4)
            Action<string[]> result4 = strings =>
                {
                    Console.WriteLine(strings[0].Length >= strings[1].Length ? strings[0] : strings[1]);
                };
            result4(new[] { "Foo", "BarBaz" });

            // (5)
            Func<string> result5 = () => DateTime.Now.ToString("yyyymmdd");
            Console.WriteLine(result5());

            // (6)
            Func<bool, bool, bool> result6 = (b1, b2) => b1 ^ b2;
            Console.WriteLine($"True XOR True = {result6(true, true)}");

            // (7)
            Action result7 = () => { };

            // (8)
            Action<Action> result8 = act =>
                {
                    act.Invoke();
                };
            result8(() => Console.WriteLine("I did it!"));
        }
    }
}