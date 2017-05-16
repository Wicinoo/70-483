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
        delegate void DummyDelegate();

        public static void Run()
        {
            // E.g. Action<DateTime> problem42 = dt => { Console.WriteLine(dt...)};
            {
                Action<string> problem1 = (s) =>
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        Console.WriteLine(s.ToCharArray()[0]);
                    }
                };

                problem1("Test");
                problem1(null);
                problem1(string.Empty);
                problem1(Environment.NewLine);
            }

            {
                Action<int[]> problem2 = (arr) =>
                {
                    if (arr == null) return;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write(new string(' ', i + 1));
                        Console.WriteLine(arr[i].ToString());
                    }
                };

                problem2(new int[] { 100, 120, 150, 190, 200 });
                problem2(new int[] { });
                problem2(null);
            }


            {
                Predicate<char> problem3 = (c) => char.IsDigit(c);

                bool isDigit = problem3('1');
                isDigit = problem3('a');
            }

            {
                Action<string, string> problem4 = (s1, s2) =>
                {
                    Func<string, int> slen = (s) => s == null ? 0 : s.Length;
                    Action<string> cw = (s) => { Console.WriteLine(s); };

                    if (slen(s1) > slen(s2)) cw(s1);
                    else if (slen(s2) > slen(s1)) cw(s2);
                    //else cw("equal length");
                };

                problem4("first", "second");
                problem4("aaa", "bbb");
                problem4(null, "not null");
                problem4(null, string.Empty);
                problem4(null, null);
            }

            {
                Func<DateTime, string> problem5 = d => d.ToString("yyyyMMdd");
                Console.WriteLine(problem5(DateTime.Now));
            }

            {
                Func<bool, bool, bool> problem6 = (b1, b2) =>
                {
                    Console.WriteLine($"{b1} XOR {b2} = {b1 ^ b2}");
                    return b1 ^ b2;
                };

                problem6(true, true);
                problem6(true, false);
                problem6(false, true);
                problem6(false, false);
            }

            {
                DummyDelegate problem7 = delegate { };
                problem7();
                problem7 = () => { };
                problem7();
            }

            /*{
                DummyDelegate actionWithoutParams = () => { Console.WriteLine("Action without parameters executed."); };
                Action<DummyDelegate> problem8 = (inputAction) => { inputAction(); };
                problem8(actionWithoutParams);
                problem8(() => Console.WriteLine("Another action without parameters executed."));
            }*/

            {
                Action emptyAction = () => { };
                Action<Action> problem8 = (action) => { action(); };
                problem8(emptyAction);
                problem8(delegate { });
            }

        }
    }
}