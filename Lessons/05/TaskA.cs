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
            Console.WriteLine(typeof(FooClass).BaseType.FullName);
            Console.WriteLine(typeof(FooStruct).BaseType.FullName);
            // Print "The ancestor type of FooClass is ?."
            // Print "The ancestor type of FooStruct is ?."
        }
    }

    class FooClass { }
    struct FooStruct { }
}
