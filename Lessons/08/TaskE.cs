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
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                        null,
                        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(DateTime) }),
                        Expression.Convert(
                            Expression.Property(
                                null,
                                typeof(DateTime),
                                "Now"),
                            typeof(object))
                       )
                );

            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}