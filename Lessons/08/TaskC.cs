using System;
using System.Collections.Generic;
using System.Linq;

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
            var fooTypes = typeof(IFoo).Assembly.GetTypes().
                Where(x => x.IsClass && typeof(IFoo).IsAssignableFrom(x));

            PrintTypes(fooTypes);

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            var fooBarInterfaces = typeof(FooBar).Assembly.GetTypes().
                Where(x => x.IsInterface && x.IsAssignableFrom(typeof(FooBar)));

            PrintTypes(fooBarInterfaces);

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            var fooTypes2 = fooTypes.Where(x => x.GetConstructors().
                Any(y => !y.GetParameters().Any()));

            PrintTypes(fooTypes2);
        }

        private static void PrintTypes(IEnumerable<Type> fooTypes)
        {
            foreach (var type in fooTypes)
            {
                Console.WriteLine(type.Name);
            }
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