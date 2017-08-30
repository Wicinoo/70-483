using System;
using System.Reflection;
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
			// #1 List all types that implement IFoo.  // FooBase, Foo, FooBar, FooBuz
			// #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
			// #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 

			Console.WriteLine(String.Join(",", GetImplementingTypes<IFoo>().Select(x => x.Name)));

			Console.WriteLine(String.Join(",", typeof(FooBar).GetInterfaces().Select(x => x.Name)));

			var types = GetImplementingTypes<IFoo>().Where(x => x.GetConstructor(Type.EmptyTypes) != null);

			Console.WriteLine(String.Join(",", types.Select(x => x.Name)));

			types.ToList().ForEach(x => Activator.CreateInstance(x));
		}

		public static IEnumerable<Type> GetImplementingTypes<T>()
		{
			var type = typeof(T);
			return AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p));
		}


        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}
