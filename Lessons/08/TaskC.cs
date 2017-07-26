using System;
using System.Linq;
using System.Reflection;
using Rhino.Mocks.Constraints;

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

            var types = Assembly.GetCallingAssembly().GetTypes();

            var fooBarTypes = typeof (FooBar).GetInterfaces();

            var iFooTypes = types.Where(type => type.GetInterfaces().Any(i => i == typeof(IFoo)));
            var iFooTypesWithConstructor =
                iFooTypes.Where(type => type.GetConstructors().Any(constructor => !constructor.GetParameters().Any()));

            Console.WriteLine(string.Join("|", iFooTypes.Select(type => type.Name)));
            Console.WriteLine(string.Join("|", fooBarTypes.Select(type => type.Name)));
            Console.WriteLine(string.Join("|", iFooTypesWithConstructor.Select(type => type.Name)));

            foreach (var type in iFooTypesWithConstructor)
            {
                Activator.CreateInstance(type);
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