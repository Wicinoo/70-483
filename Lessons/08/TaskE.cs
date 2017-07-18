using System;
using System.Linq.Expressions;

using FluentAssertions.Common;

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

            BlockExpression block1 =
                Expression.Block(
                    Expression.Call(
                        typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
                        Expression.Constant(DateTime.Now.ToString())));

            Expression.Lambda<Action>(block1).Compile()();



            //var dtn = typeof(DateTime).GetPropertyByName("Now").GetValue(null);
            //var nst = Expression.Block(Expression.Call(typeof(Convert).GetMethod("ToString", new[] { typeof(DateTime) }), Expression.Constant(dtn)));

            //Console.WriteLine($"{Expression.Lambda<Action>(nst).Compile()}");


            //BlockExpression block =
            //    Expression.Block(
            //        Expression.Call(
            //            typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
            //            Expression.Constant(

            //                Expression.Call(typeof(Convert).GetMethod("ToString", new[] { typeof(DateTime) }), Expression.Constant(dtn))

            //                )));

            //Expression.Lambda<Action>(block).Compile()();

            
        }
    }
}

