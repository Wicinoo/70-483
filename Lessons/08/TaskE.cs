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
            var blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(object) }),
                    Expression.Convert(
                    Expression.Property(
                        null,
                        typeof(DateTime).GetProperty("Now")
                        ), typeof(object))
                    )
                );

            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}