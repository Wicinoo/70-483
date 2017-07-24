using Castle.Core.Internal;
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
            // get types from current domain
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(type => type.GetInterfaces().Contains(typeof(IFoo))).ForEach(type => Console.WriteLine(type.Name));
            // get type form class
            typeof(TaskC).Assembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IFoo))).ForEach(type => Console.WriteLine(type.Name));

            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(type => type.IsInterface && type.IsInstanceOfType(new FooBar())).ForEach(type => Console.WriteLine(type.Name));

            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            //???
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}