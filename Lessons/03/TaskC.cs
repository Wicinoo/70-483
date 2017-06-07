using System;

namespace Lessons._03
{
    /// <summary>
    /// Use ?? operator to implement lazy initialization of _foo backing field 
    /// in Foo getter.
    /// </summary>
    public class TaskC
    {
        private static Foo _foo;

        public static void Run()
        {
            Console.WriteLine($"_foo: {_foo}");
            Console.WriteLine($"_foo: {Foo}");
        }

        public static Foo Foo
        {
            get
            {
                _foo = _foo ?? new Foo();
                return _foo;
            }
        }
    }

    public class Foo { }
}