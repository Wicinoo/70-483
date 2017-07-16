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
            var iFooTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(x => x == typeof(IFoo)));

            PrintTypes(iFooTypes);

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar

            var fooBarInterfaces = typeof(FooBar).GetInterfaces();

            PrintTypes(fooBarInterfaces);

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar

            var iFooNewTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(x => x == typeof(IFoo)) &&
                            t.GetConstructors().Any(c => !c.GetParameters().Any() && c.IsPublic));

            PrintTypes(iFooNewTypes);

            foreach (var iFooNewType in iFooNewTypes)
            {
                var instance = Activator.CreateInstance(iFooNewType);

                Console.WriteLine(instance.GetType().Name);
            }
        }

        private static void PrintTypes(System.Collections.Generic.IEnumerable<Type> iFooTypes)
        {
            Console.WriteLine(string.Join(", ", iFooTypes.Select(x => x.Name)));
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}