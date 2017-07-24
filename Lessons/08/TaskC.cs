using System;
using System.Collections.Generic;
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
            var listAllTypesImplementingIFoo =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => type.GetInterfaces().Any(i => i == typeof(IFoo)));

            PrintList("ListOfTypesImplementingIFoo", listAllTypesImplementingIFoo);

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            var listAllInterfacesImplementedByFooBar = typeof(FooBar).GetInterfaces();

            PrintList("ListAllInterfacesImplementedByFooBar", listAllInterfacesImplementedByFooBar);

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            var listImplementingIFooWithParameterlessConstructor =
                listAllTypesImplementingIFoo.Where(
                    t => t.GetConstructors().Any(c => !c.GetParameters().Any() && c.IsPublic));

            PrintList("ListImplementingIFooWithParameterlessConstructor", listImplementingIFooWithParameterlessConstructor);
        }

        private static void PrintList(string header, IEnumerable<Type> iFooTypes)
        {
            Console.WriteLine(header);
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