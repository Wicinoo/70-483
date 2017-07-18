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
            // #2 List all interfaces that are implemented by FooBar. // IFoo, IBar
            // #3 List all types that implement IFoo and can be instantiated with using parameterless constuctor. Instantiate them. // Foo, FooBar 
            var assembly = Assembly.GetCallingAssembly();
            var assemblyTypes = assembly.GetTypes();

            Console.WriteLine("types implementing IFoo");
            var typesImplementingIFoo = GetTypesImplementingIFoo(assemblyTypes);
            typesImplementingIFoo.ForEach(x => Console.WriteLine(x.Name));

            Console.WriteLine("interfaces implemented by FooBar");
            var interfacesImplementedByFooBar = GetInterfacesImplementedByFooBar(assemblyTypes);
            interfacesImplementedByFooBar.ForEach(x => Console.WriteLine(x.Name));

            Console.WriteLine("types implementing IFoo with parameterless constructor");
            var typesImplementingIFooWithParameterlessConstructor = typesImplementingIFoo.Where(x => x.GetConstructor(Type.EmptyTypes) != null).ToList();
            typesImplementingIFooWithParameterlessConstructor.ForEach(x => Console.WriteLine(x.Name));
            typesImplementingIFooWithParameterlessConstructor.ForEach(x => InstantiateTypes(x));
        }

        private static void InstantiateTypes(Type type)
        {
            var instance = Activator.CreateInstance(type);
            Console.WriteLine("instance of: " + instance.GetType().Name);
        }

        private static List<Type> GetInterfacesImplementedByFooBar(Type[] assemblyTypes)
        {
            var typeName = typeof(FooBar).Name;
            // could not access assembly to search specific type, got a null reference on second call to Assembly.GetCallingAssembly()
            var fooBarAssemblyType = assemblyTypes.First(x => string.Equals(x.Name, typeName, StringComparison.OrdinalIgnoreCase));

            return fooBarAssemblyType.GetInterfaces().ToList();
        }

        private static List<Type> GetTypesImplementingIFoo(Type[] assemblyTypes)
        {
            return assemblyTypes.Where(x => x.IsAssignableFrom(typeof(IFoo))).ToList();
        }

        interface IFoo { }
        interface IBar { }
        abstract class FooBase : IFoo { }
        class Foo : IFoo { }
        class FooBar : FooBase, IBar { }
        sealed class FooBuz : IFoo { FooBuz(string buz) { } }
    }
}