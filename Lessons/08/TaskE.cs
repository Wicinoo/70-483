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
			//what in the hell is this usefull for anyway? Its like our legacy code on steroids
			((Expression<Action>)(() => Console.WriteLine(DateTime.Now))).Compile()();
			
		}
    }
}