using System;

namespace Lessons._08
{
    using System.Linq.Expressions;

    /// <summary>
    /// Create an expression (System.Linq.Expressions.Expression) for the code:
    ///  Console.WriteLine(DateTime.Now)
    /// Compile it and run it.
    /// </summary>
    public class TaskE
    {
        public static void Run()
        {
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant(DateTime.Now.ToString())
                    )
                );

            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}