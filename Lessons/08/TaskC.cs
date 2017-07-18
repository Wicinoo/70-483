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
            var type = typeof(IFoo);
            var typesImplementedByIFoo = GetTypesImplemetedBy(type);
            Console.WriteLine("#1 List all types that implement IFoo.  // FooBase, Foo, FooBar, FooBuz");
            PrintTypes(typesImplementedByIFoo);

            var typeOfFooBar = typeof(FooBar);
            var types = type.GetInterfaces();
            Console.WriteLine("#2 List all interfaces that are implemented by FooBar. // IFoo, IBar");
            PrintTypes(types);

            Console.WriteLine("#3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar ");
            foreach (var item in typesImplementedByIFoo)
            {
                var contstructor = item.GetConstructor(Type.EmptyTypes);

                if (contstructor != null)
                {
                    Console.WriteLine(item.Name);
                    Activator.CreateInstance(item);
                }
            }
        }

        private static IEnumerable<Type> GetTypesImplemetedBy(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(x => type.IsAssignableFrom(x));
        }

        private static void PrintTypes(IEnumerable<Type> types)
        {
            foreach (var item in types)
            {
                Console.WriteLine(item.Name);
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