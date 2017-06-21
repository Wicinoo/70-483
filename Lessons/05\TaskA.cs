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
            FooClass OneFooClass = new FooClass();
            // Print "The ancestor type of FooClass is ?."
            Console.WriteLine("The ancestor type of FooClass is " + OneFooClass.GetType().BaseType.Name);

            FooStruct OneFooStruct = new FooStruct();
            // Print "The ancestor type of FooStruct is ?."
            Console.WriteLine("The ancestor type of FooStruct is " + OneFooStruct.GetType().BaseType.Name);
        }
    }
    class FooClass { }
    struct FooStruct { }
}
