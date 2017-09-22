using System;
using System.Linq;
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
            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 

            var iFoo = typeof(IFoo);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type => iFoo.IsAssignableFrom(type) && iFoo != type);

            foreach (var type in types)
            {
                Console.WriteLine($"(1) {iFoo} is implemented by {type}");
            }

            var fooBar = typeof (FooBar);
            types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type => type.IsAssignableFrom(fooBar) && type.IsInterface);

            foreach (var type in types)
            {
                Console.WriteLine($"(2) {type} is implemented by {fooBar}");
            }

            types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type => iFoo.IsAssignableFrom(type) && type.GetConstructor(Type.EmptyTypes) != null);

            foreach (var type in types)
            {
                Console.WriteLine($"(3) {iFoo} is implemented by {type} and has parameterless constructor.");
                var constructedType = Activator.CreateInstance(type);
                Console.WriteLine($"(3) Created instance {constructedType} of {type}");
            }
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}