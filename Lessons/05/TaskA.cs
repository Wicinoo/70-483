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
            Console.WriteLine("The ancestor of " + new FooClass().GetType().Name + " is: " + new FooClass().GetType().BaseType.Name);

            // Print "The ancestor type of FooStruct is ?."
            Console.WriteLine("The ancestor of " + new FooStruct().GetType().Name + " is: " + new FooStruct().GetType().BaseType.Name);
        }
    }

    class FooClass { }
    struct FooStruct { }
}
