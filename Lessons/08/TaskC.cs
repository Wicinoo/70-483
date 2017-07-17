using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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


            Console.WriteLine("IFoo implementations.");
            foreach (var item in GetAllDerrivedTypes(typeof(IFoo)))
            {
                Console.WriteLine($"    {item}");
            }

            Console.WriteLine("Interfaces implemented by FooBar");
            foreach (var item in typeof(FooBar).GetInterfaces())
            {
                Console.WriteLine($"    {item}");
            }

            Console.WriteLine("IFoo implementations with parameterless constructor.");
            foreach (var item in GetAllDerrivedTypes(typeof(IFoo)))
            {
                var constructor = item.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    Activator.CreateInstance(item);
                    Console.WriteLine($"    {item}");
                }
            }

        }

        private static System.Collections.Generic.IEnumerable<Type> GetAllDerrivedTypes(Type interfaceType)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p));
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}