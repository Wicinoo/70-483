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
            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 

            ImplementIFoo();
            InterfacesOfFooBar();
            ClassesWithParameterlessConstructor();
        }

        private static void ImplementIFoo()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IFoo).IsAssignableFrom(p));

            Console.WriteLine("Types that implement IFoo:");
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine();
        }

        private static void InterfacesOfFooBar()
        {
            var types = typeof(FooBar).GetInterfaces();

            Console.WriteLine("All interfaces that are implemented by FooBar:");
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine();
        }

        private static void ClassesWithParameterlessConstructor()
        {
            var ctors = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IFoo).IsAssignableFrom(p))
                .SelectMany(p => p.GetConstructors())
                .Where(x => x.GetParameters().Length == 0);

            Console.WriteLine("All types that implement IFoo and can be instantiated with using parameterless constuctor:");
            foreach (var ctor in ctors)
            {
                ctor.Invoke(null);
                Console.WriteLine(ctor.ReflectedType);
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