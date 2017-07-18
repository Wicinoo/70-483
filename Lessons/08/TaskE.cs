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
            var expr = Expression.Convert(Expression.Constant(DateTime.Now), typeof(object));
            var dtExpression = Expression.Call(null,
                typeof(Console).GetMethod("WriteLine", new Type[] {typeof(DateTime)}),
                expr);
            Expression.Lambda<Action>(dtExpression).Compile()();
        }
    }
}