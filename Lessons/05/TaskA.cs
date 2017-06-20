using System;

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
            Console.WriteLine(typeof(FooClass).BaseType);
            Console.WriteLine(typeof(FooStruct).BaseType);
        }
    }

    class FooClass { }
    struct FooStruct { }
}
