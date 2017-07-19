using System;
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
            var fooType = typeof(IFoo);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => fooType.IsAssignableFrom(p) && !p.IsInterface)
                .Select(type => type.Name);
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine();

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            var interfaces = typeof(FooBar).GetInterfaces().Select(type => type.Name);
            foreach (var myInterface in interfaces)
            {
                Console.WriteLine(myInterface);
            }

            Console.WriteLine();

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            var iFooType = typeof(IFoo);
            var iFooTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => iFooType.IsAssignableFrom(p));
            foreach (var myType in iFooTypes)
            {
                var ctor = myType.GetConstructor(Type.EmptyTypes);
                if (ctor != null)
                {
                    Activator.CreateInstance(myType);
                    Console.WriteLine(myType.Name);
                }
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