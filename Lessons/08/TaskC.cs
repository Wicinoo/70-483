using System;
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
            var listOne =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => (typeof(IFoo)).IsAssignableFrom(type))
                    .ToList();

            foreach (var type in listOne)
            {
                Console.WriteLine($"list one contains {type}");
            }

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            var listTwo = (typeof(FooBar)).GetInterfaces();

            foreach (var type in listTwo)
            {
                Console.WriteLine($"list two contains {type}");
            }

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            foreach (var type in listOne)
            {
                if (type.GetConstructor(Type.EmptyTypes) != null)
                {
                    Console.WriteLine($"list three contains {type}");
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