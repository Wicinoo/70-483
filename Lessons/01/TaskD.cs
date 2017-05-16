using System;
using Rhino.Mocks.Constraints;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public delegate A Create();

        public static void Run()
        {
            Create[] createCollection = {CreateA, CreateB, CreateC};

            foreach (var create in createCollection)
            {
                var product = create();

                Console.Out.WriteLine($"I've created product {product.GetType().Name}.");
            }
        }

        public static A CreateA()
        {
            return new A();
        }

        public static B CreateB()
        {
            return new B();
        }

        public static C CreateC()
        {
            return new C();
        }
    }

    public class A
    {
        
    }

    public class B : A
    {
        
    }

    public class C : A
    {
        
    }
}