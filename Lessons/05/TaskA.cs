using System;
using System.Windows.Data;

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
            RelativeSource classRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(FooClass), 1);
            RelativeSource structRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(FooStruct), 1);

            Console.WriteLine($"The ancestor type of FooClass is {classRelativeSource.AncestorType}.");
            Console.WriteLine($"The ancestor type of FooStuct is {structRelativeSource.AncestorType}.");
        }
    }

    class FooClass { }
    struct FooStruct { }
}
