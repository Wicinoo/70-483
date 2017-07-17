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
			var expr = Expression.Call(
					null,
					typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
					Expression.Constant("Hello ")
					);

			Expression.Lambda<Action>(expr).Compile()();

		}
    }
}