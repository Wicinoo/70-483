using System;
using System.Linq.Expressions;

namespace Lessons._08
{
    public static class _02_ExpressionTrees
    {
        public static void Run()
        {
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof (Console).GetMethod("Write", new Type[] {typeof (String)}),
                    Expression.Constant("Hello ")
                    ),
                Expression.Call(
                    null,
                    typeof (Console).GetMethod("WriteLine", new Type[] {typeof (String)}),
                    Expression.Constant("World!")
                    )
                );

            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}