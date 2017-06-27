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
            System.Console.WriteLine(typeof(FooClass).BaseType.ToString());
            // Print "The ancestor type of FooStruct is ?."
            System.Console.WriteLine(typeof(FooStruct).BaseType.ToString());
        }
    }

    class FooClass { }
    struct FooStruct { }
}
