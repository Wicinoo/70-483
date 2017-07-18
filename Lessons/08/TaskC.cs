using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Castle.Core.Internal;

using FluentAssertions.Common;

namespace Lessons._08
{
    /// <summary>
    /// Solve all three subtasks below with using reflection.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            // #1 List all types that implement IFoo.  // FooBase, Foo, FooBar, FooBuz
            typeof(TaskC).Assembly.GetTypes().Where(type => type.Implements(typeof(IFoo))).ForEach(type => Console.WriteLine($"{type.Name}"));
            Console.WriteLine();
            
            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            typeof(TaskC).Assembly.GetTypes().Where(type => type.IsAssignableFrom(typeof(FooBar))).ForEach(type => Console.WriteLine($"{type.Name}"));
            Console.WriteLine();

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            typeof(TaskC).Assembly.GetTypes()
                .Where(type => type.Implements(typeof(IFoo)) && type.GetConstructor(Type.EmptyTypes) != null)
                .ForEach(type => Console.WriteLine($"{type.Name}"));
            Console.WriteLine();

        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}