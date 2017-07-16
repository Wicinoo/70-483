using System;
using System.Linq.Expressions;

namespace Lessons._08
{
    /// <summary>
    /// Create an expression (System.Linq.Expressions.Expression) for the code:
    ///  Console.WriteLine(DateTime.Now)
    /// Compile it and run it.
    /// </summary>
    public class TaskE
    {
        public static void Run()
        {
            Expression<Action> exp = () => Console.WriteLine(DateTime.Now);

            var compiledExp = exp.Compile();

            compiledExp();
        }
    }
}