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
            var fooClass = new FooClass();
            var fooClassAncFullName = string.Empty;

            var fooClassBaseType = fooClass.GetType().BaseType;
            if (fooClassBaseType != null)
            {
                fooClassAncFullName = fooClassBaseType.FullName;
            }

            Console.WriteLine($"The ancestor type of {fooClass.GetType().FullName} is {fooClassAncFullName}");

            // Print "The ancestor type of FooStruct is ?."
            var fooStruct = new FooStruct();
            var fooStructAncFullName = string.Empty;

            var fooStructBaseType = fooStruct.GetType().BaseType;
            if (fooStructBaseType != null)
            {
                fooStructAncFullName = fooStructBaseType.FullName;
            }

            Console.WriteLine($"The ancestor type of {fooStruct.GetType().Name} is {fooStructAncFullName}");        
        }
    }

    class FooClass { }

    struct FooStruct { }
}
