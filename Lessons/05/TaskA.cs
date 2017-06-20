using System;
using System.Reflection;

namespace Lessons._05
{
    /// <summary>
    /// Print the ancestors of FooClass and FooStruct.
    /// Don't use "FooClass" and "FooStruct" as magic strings. 
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            PrintAncestor((new FooClass()).GetType());
            PrintAncestor((new FooStruct()).GetType());
        }

        private static void PrintAncestor(Type type)
        {
            Console.WriteLine("The ancestor type of " + type.Name + " is " + type.BaseType + ".");
        }
    }

    class FooClass { }
    struct FooStruct { }
}
