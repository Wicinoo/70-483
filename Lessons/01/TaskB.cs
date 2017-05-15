using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            MapString msDelegate = delegate (string s) { return "Anonymous method: " + s; };
            msDelegate += (string s) => { return "Lambda expression (explicitly typed parameter): " + s; };
            msDelegate += (s) => { return "Lambda expression (implicitly typed parameter): " + s; };
            msDelegate += s => { return "Lambda expression (implicitly typed parameter): " + s; };
            msDelegate += s => "Lambda expression (implicitly typed parameter): " + s; 

            foreach (Delegate d in msDelegate.GetInvocationList())
            {
                MapString msd = (MapString)d;
                Console.WriteLine(msd("Some string"));
            }
        }
    }

    public delegate string MapString(string @string);
}