using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons._05
{
    public class Demo
    {
        class ReferenceFoo
        {
            public int Number { get; set; }
        }

        struct ValueBar
        {
            public int Number { get; set; }
        }

        public static void Run()
        {
            // Reference vs. value types

            var foo = new ReferenceFoo() { Number = 1 };
            var bar = new ValueBar() { Number = 1 };

            SetNumberTo0(bar);

            Console.WriteLine(bar.Number);

            Console.WriteLine(AreTheSame(foo, foo));
            Console.WriteLine(AreTheSame(bar, bar));
            
            // Ancestor of types

            // Non-generic solution first
            PrintTypeAndItsAncestor<ReferenceFoo>();
            PrintTypeAndItsAncestor<ValueBar>();
            PrintTypeAndItsAncestor<ValueType>();

            // Memory management - heap, stack
            // Where do foo and bar instances live?

            // Other important value types
            // Boolean, Byte, DateTime, TimeSpan, Decimal, Guid, IntX, UIntX, Nullable<T>, Void, ...
            
            // Value types for small objects, logically immutable, a lot of such instances.

            // Enums - simple type, mapping values to non-default values, flags

            ProgrammingLanguage language = ProgrammingLanguage.CSharp | ProgrammingLanguage.Java;
            Console.WriteLine(language);
            Console.WriteLine("Is Java: {0}", language.HasFlag(ProgrammingLanguage.Java));

            PrintTypeAndItsAncestor<ProgrammingLanguage>();
            PrintTypeAndItsAncestor<Enum>();

            // Listing all values of an enum - using an extension method

            Enum.GetValues(typeof(ProgrammingLanguage))
                .Cast<ProgrammingLanguage>()
                .ForEach(value => Console.WriteLine(value));

            // Methods or functions? - default, named parameters

            // Law of Demeter
            // Don't speak to friends of your friends

            // Naming conventions

            // Design principles - SOLID, see DemoSolid

            // Generic types

            // Extension methods
        }

        [Flags]
        public enum ProgrammingLanguage
        {
            CSharp = 0x01,
            Java = 0x02
        }

        // Initializing fields vs. local variables

        class Baz
        {
            public int _intField;
            public DateTime _DateTime;

            public Baz()
            {
                var intVariable = 0;
            }
        }

        // Static vs non-static types / fields

        class Qux
        {
            public static int IntProperty { get; set; }
        }

        // Constructors - best practices

        class Quux
        {
            public Quux()
            {
            }

            public Quux(int seed) : this()
            {
                
            }
        }

        private static void SetNumberTo0(ValueBar foo)
        {
            foo.Number = 0;
        }

        private static void PrintTypeAndItsAncestor<T>()
        {
            Console.WriteLine("Ancestor of {0} is {1}",
                typeof(T).Name, typeof(T).BaseType.Name);
        }

        private static bool AreTheSame(object o1, object o2)
        {
            return o1.Equals(o2);
            return o1 == o2;
        }
    }

    // Generics and extension method

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }            
        }
    }
}