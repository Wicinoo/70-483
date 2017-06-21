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
            // Print "The ancestor type of FooClass is ?."
            Console.WriteLine(typeof(FooClass).BaseType);

            // Print "The ancestor type of FooStruct is ?."
            Console.WriteLine(typeof(FooStruct).BaseType);
        }
    }

    class FooClass { }
    struct FooStruct { }
}
