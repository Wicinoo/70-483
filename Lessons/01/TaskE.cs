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
    public delegate void Printer(string input);
    public delegate void PrintArray(int[] input);
    public delegate bool isLetterOrDigit(char input);
    public delegate void LongerOfTwoStrings(string s1, string s2);
    public delegate string CurrentDate_yyyyMMdd();
    public delegate bool XORresult(bool bool1, bool bool2);
    public delegate void Empty();
    public delegate void ParameterlessAction(Action inputDel);

    public class TaskE
    {
        public static void Run()
        {
            // (1) An anonymous method that prints the first char from input string to the console.
            Printer p = delegate (string input) { Console.WriteLine(input[0]); };
            p("The delegate using the anonymous method is called.");

            // (2) An anonymous method with an integer array as an input that prints all values to the console.
            // Each value is preceded by the number of spaces according to the position of the item.
            // "(itemAtPosition0)"
            // " (itemAtPosition1)"
            // "  (itemAtPosition2)"
            // ...
            PrintArray arr = delegate (int[] input)
            {
                string a = "";

                foreach (var item in input)
                {
                    Console.Write(a + item + "\r\n"); a += " ";
                }
            };

            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            arr(numbers);

            // (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
            isLetterOrDigit IsIt = delegate (char input) { return Char.IsLetterOrDigit(input); };
            Console.WriteLine(IsIt('/'));

            // (4) An anonymous method that prints longer string from a pair of strings to the console.
            LongerOfTwoStrings Longer = delegate (string s1, string s2)
            {
                if (s2.Length > s1.Length)
                {
                    Console.WriteLine(s2);
                }
                else
                {
                    Console.WriteLine(s1);
                }
            };

            Longer("a", "ab");

            // (5) An anonymous function that returns current date in "yyyymmdd" format.
            CurrentDate_yyyyMMdd CurrentDate = delegate () { return DateTime.Now.ToString("yyyyMMdd"); };
            Console.WriteLine(CurrentDate());

            // (6) An anonymous function that returns XOR result of two input boolean values.
            XORresult XORXOR = delegate (bool bool1, bool bool2) { return bool1 ^ bool2; };
            Console.WriteLine(XORXOR(true, false));

            // (7) An anonymous empty method.
            Empty emp = delegate () { };
            emp();

            // (8) An anonymous method that gets apr parameterless action as an input and invokes that action.
            ParameterlessAction param = delegate (Action inputDel) { inputDel(); };
            Action invoking = () => { Console.WriteLine("Invoking the parameterless action"); };
            param(invoking);
        }
    }
}
