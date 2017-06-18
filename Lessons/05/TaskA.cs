using System;
using System.Windows;

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
			Console.WriteLine("The ancestor type of FooClass is ?.");
			// Print "The ancestor type of FooStruct is ?."
			Console.WriteLine("The ancestor type of FooStruct is ?.");
			//Technically correct. The best kind of correct

			

			Console.WriteLine(typeof(FooClass).BaseType.ToString());
			Console.WriteLine(typeof(FooStruct).BaseType.ToString());
		}
	}

    class FooClass { }
    struct FooStruct { }
}
