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
            Console.WriteLine("TaskE:");
            Console.WriteLine("---------------------------------------");
            Action<string> p1 = str => 
            {
                if (str.Length > 0)
                    Console.WriteLine(str[0]);
                else
                    Console.WriteLine("");
            };

            Action<int[]> p2 = ints =>
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    Console.WriteLine(ints[i].ToString().PadLeft(i, ' '));
                }
            };

            Predicate<char> p3 = c => { return Char.IsLetterOrDigit(c); };

            Action<string, string> p4 = (s1, s2) => 
            {
                if (s1.Length > s2.Length)
                    Console.WriteLine(s1);
                else
                    Console.WriteLine(s2); 
            };

            Func<string> p5 = () => { return DateTime.Now.ToString("yyyyMMdd"); };

            Func<bool, bool, bool> p6 = (b1, b2) => { return b1 ^ b2; };

            Action p7 = () => { };

            Action<Action> p8 = (act) => act();

            p1("aaa");
            p2(new int[] { 8, 4, 6, 7, 8, 654, 897, 18, 7198, 719 });
            p3('a');
            p4("aaaaaa","aaaaaaaaaa");
            p5();
            p6(true, false);
            p7();
            p8(p7);
            Console.WriteLine("---------------------------------------");
        }
    }
}
