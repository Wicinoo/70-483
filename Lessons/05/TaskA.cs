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
            PrintBaseType(new FooClass());
            PrintBaseType(new FooStruct());
            // Print "The ancestor type of FooClass is ?."
            // Print "The ancestor type of FooStruct is ?."
        }

        private static void PrintBaseType(Object t)
        {
            var type = t.GetType();
            System.Console.WriteLine($"The ancestor type of {type} is {type.BaseType}.");
        }
    }


    class FooClass { }
    struct FooStruct { }
}
