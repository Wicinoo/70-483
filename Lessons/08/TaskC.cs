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
            var type = typeof(IFoo);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            foreach (var oneType in types)
            {
                Console.WriteLine(oneType);
            }
            Console.WriteLine();

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            var interfaces = typeof(FooBar).GetInterfaces();
            foreach (var oneInterface in interfaces)
            {
                Console.WriteLine(oneInterface);
            }
            Console.WriteLine();

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            var type2 = typeof(IFoo);
            var types2 = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type2.IsAssignableFrom(p));
            foreach (var oneType in types2)
            {
                var ctor = oneType.GetConstructor(Type.EmptyTypes);
                if (ctor != null)
                {
                    Activator.CreateInstance(oneType);
                    Console.WriteLine(oneType);
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