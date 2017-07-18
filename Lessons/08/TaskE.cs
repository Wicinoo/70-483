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
            var instance = new TaskE();
            instance.RunInstance();
        }

        public static void PrintDateTimeNow()
        {
            Console.WriteLine(DateTime.Now);
        }

        private void RunInstance()
        {
            var printDateNow = Expression.Lambda<Action>(Expression.Call(typeof(TaskE).GetMethod("PrintDateTimeNow")));
            var compiled = printDateNow.Compile();
            compiled.DynamicInvoke();
        }
    }
}