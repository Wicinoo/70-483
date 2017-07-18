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

            Console.WriteLine("#1 List all types that implement IFoo");
            var iFooImplementations =
                typeof(IFoo).Assembly.GetTypes().Where(type => typeof(IFoo).IsAssignableFrom(type) && !type.IsInterface)
                    .Select(type => type.Name).ToList();
            iFooImplementations.ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("#2 List all interfaces that are implemented by FooBar.");
            var fooBarImplementations = typeof(FooBar).Assembly.GetTypes()
                .Where(type => type.IsAssignableFrom(typeof(FooBar)) && type.IsInterface)
                .Select(type => type.Name).ToList();
            fooBarImplementations.ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine(
                "#3 List all types that implement IFoo and can be instantiated with using parameterless constuctor.");
            var instanses = typeof(IFoo).Assembly.GetTypes()
                .Where(type => typeof(IFoo).IsAssignableFrom(type) && !type.IsInterface &&
                               type.GetConstructor(Type.EmptyTypes) != null).ToList();
            instanses.ForEach(i => Console.WriteLine(i.Name));
            instanses.ForEach(i => Activator.CreateInstance(i));
        }

        interface IFoo
        {
        }

        interface IBar
        {
        }

        abstract class FooBase : IFoo
        {
        }

        class Foo : IFoo
        {
        }

        class FooBar : FooBase, IBar
        {
        }

        sealed class FooBuz : IFoo
        {
            FooBuz(string buz)
            {
            }
        }
    }
}