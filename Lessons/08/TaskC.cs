using System;
using System.Linq;
using Castle.Core.Internal;
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
            var type = typeof (IFoo);
            var types =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => type.IsAssignableFrom(x) && type != x);
            Console.WriteLine();
            types.ForEach(x => Console.WriteLine(x.FullName));

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            type = typeof (FooBar);
            types =
                AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => type.Implements(x) && !x.IsClass);
            Console.WriteLine();
            types.ForEach(x => Console.WriteLine(x.FullName));
            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 

            type = typeof(IFoo);
            types =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => type.IsAssignableFrom(x) && type != x && x.GetConstructor(Type.EmptyTypes) != null);
            Console.WriteLine();
            types.ForEach(x =>
            {
                Console.WriteLine(x.FullName);
                x.GetConstructor(Type.EmptyTypes).Invoke(null);
            });
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}