using System;
using System.Globalization;
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
            var expr = Expression.Call(
                null,
                typeof (Console).GetMethod("WriteLine", new[] { typeof (string) }),
                Expression.Constant(DateTime.Now.ToString(CultureInfo.InvariantCulture))
                );

            Expression.Lambda<Action>(expr).Compile()();
        }
    }
}