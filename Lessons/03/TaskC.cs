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
            try
            {
                Console.WriteLine(_foo);
                Console.WriteLine(Foo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static Foo Foo
        {
            get
            {
                return _foo ?? new Foo();
            }
        }
    }
    public class Foo { }
}