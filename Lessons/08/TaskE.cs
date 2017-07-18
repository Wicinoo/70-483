using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

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

            var methodCallExpression = Expression.Call(
                null,
                typeof(Console).GetMethod("WriteLine", new Type[] {typeof(String)}),
                Expression.Constant(DateTime.Now.ToString())
            );

            Expression<Action> expression = Expression.Lambda<Action>(methodCallExpression);


            expression.Compile().DynamicInvoke();
        }
    }
}