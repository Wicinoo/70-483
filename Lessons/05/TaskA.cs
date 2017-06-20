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
            Console.WriteLine("The ancestor type of " + typeof(FooClass).Name + " is " + typeof(FooClass).BaseType);
            Console.WriteLine("The ancestor type of " + typeof(FooStruct).Name + " is " + typeof(FooStruct).BaseType);
            // Print "The ancestor type of FooClass is ?."
            // Print "The ancestor type of FooStruct is ?."
        }
    }

    class FooClass { }
    struct FooStruct { }
}
