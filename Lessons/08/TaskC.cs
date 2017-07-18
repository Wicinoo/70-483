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

            foreach (var source in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IFoo).IsAssignableFrom(p) && p != typeof(IFoo)))
            {
                Console.WriteLine(source.Name);
            }

            foreach (var source in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsInterface && p.IsAssignableFrom(typeof(FooBar))))
            {
                Console.WriteLine(source.Name);
            }

            var specialTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof (IFoo).IsAssignableFrom(p) && p != typeof (IFoo));

            foreach (var specialType in specialTypes)
            {
                var constructor = specialType.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    var instance = constructor.Invoke(new object[] {});
                }

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