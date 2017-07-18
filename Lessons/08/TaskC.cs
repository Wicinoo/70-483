using System;
using System.Linq;
using System.Reflection;

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
            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 

            var types = Assembly.GetExecutingAssembly().GetTypes();

            var iFooTypes = types.Where(type => type.GetInterfaces().Any(x => x == typeof(IFoo)));

            var iFooWithConstructorTypes = iFooTypes.Where(type => type.GetConstructors().Any(c => !c.GetParameters().Any()));

            var fooBarInterfaces = typeof(FooBar).GetInterfaces();

            Console.WriteLine(string.Join(", ", iFooTypes.Select(x => x.Name)));
            Console.WriteLine(string.Join(", ", fooBarInterfaces.Select(x => x.Name)));
            Console.WriteLine(string.Join(", ", iFooWithConstructorTypes.Select(x => x.Name)));
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}