using System;
using System.Linq;
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
            Console.WriteLine($"before declaration {DateTime.Now.ToString()}");
            BlockExpression block =
                Expression.Block(
                    Expression.Call(
                        typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
                        Expression.Constant(DateTime.Now.ToString())));

            //the value from date time is compiled to expression like constant
            Expression.Lambda<Action>(block).Compile()();
            System.Threading.Thread.Sleep(1000);
            Expression.Lambda<Action>(block).Compile()();          
        }
    }
}