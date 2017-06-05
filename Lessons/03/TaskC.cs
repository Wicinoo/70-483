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
            Console.WriteLine(_foo + " is null");
            Console.WriteLine(Foo.Result);
        }

        public static Foo Foo
        {
            get
            {
                return _foo ?? (_foo = new Foo("hello, world"));
            }
        }
    }

    public class Foo
    {
        public string Result { get; set; }

        public Foo(string result)
        {
            Result = result;
        }
    }
}