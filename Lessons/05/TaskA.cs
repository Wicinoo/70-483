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
            Console.WriteLine($"The ancestor type of FooClass is {typeof(FooClass).BaseType.Name}.");

            Console.WriteLine($"The ancestor type of FooStruct is {typeof(FooStruct).BaseType.Name}.");
        }
    }

    class FooClass { }
    struct FooStruct { }
}
