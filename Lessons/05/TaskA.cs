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
            PrintInfo(typeof(FooClass));
            // Print "The ancestor type of FooStruct is ?."
            PrintInfo(typeof(FooStruct));
        }

        private static void PrintInfo(Type type)
        {
            Console.WriteLine($"The ancestor type of {type.Name} is {type.BaseType}");
        }
    }

    class FooClass { }
    struct FooStruct { }
}
