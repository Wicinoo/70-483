using System;

namespace Lessons._08
{
    using System.Linq;
    using System.Reflection;

    using Castle.Core.Internal;

    /// <summary>
    /// Solve all three subtasks below with using reflection.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            TypeFilter theFilter = new TypeFilter( (type, criteria) => true );

            // #1 List all types that implement IFoo.  // FooBase, Foo, FooBar, FooBuz
            var types1 = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(IFoo).IsAssignableFrom(p));
            types1.ForEach(x => Console.WriteLine(x));

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            var types2 = typeof(FooBar).FindInterfaces(theFilter, typeof(FooBar).BaseType);
            ;
            types2.ForEach(x => Console.WriteLine(x));

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            var types3 = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(IFoo).IsAssignableFrom(p))
                    .Where(p => p.GetConstructor(Type.EmptyTypes) != null);
            types3.ForEach(x => Console.WriteLine(x));
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}