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
            var classType = (new FooClass()).GetType();
            var structType = (new FooStruct()).GetType();
            // Print "The ancestor type of FooClass is ?."
            Console.WriteLine(classType.BaseType);
            // Print "The ancestor type of FooStruct is ?."
            Console.WriteLine(structType.BaseType);
        }
    }

    class FooClass { }
    struct FooStruct { }
}
