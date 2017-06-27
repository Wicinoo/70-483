using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;

namespace Lessons._06
{
    public class Demo
    {
        struct Money : IFormattable
        {
            public decimal Amount { get; }

            public Money(decimal amount)
            {
                Amount = amount;
            }

            public static implicit operator Money(decimal amount)
            {
                return new Money(amount);
            }

            public static implicit operator decimal(Money money)
            {
                return money.Amount;
            }

            public string ToString(string format, IFormatProvider formatProvider)
            {
                return Amount.ToString("C2", new CultureInfo("cs-CZ"));
            }
        }

        class MyDynamic : DynamicObject
        {
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = binder.Name;
                return true;
            }
        }

        public static void Run()
        {
            // Boxing, unboxing

            var typeOfInt32 = 1.GetType();
            IComparable boxedValue = 1;
            var unboxedValue = (int)boxedValue;

            // Implicit, explicit conversions

            Int64 int64 = 1;
            Int32 int32 = (int)int64;

            // Performance generic vs non-generic class

            const int Loops = 1000000;

            DoAndPrintDuration(() =>
            {
                var ngStack = new Stack();
                for (int i = 0; i < Loops; i++)
                {
                    ngStack.Push(1);
                    int value = (int)ngStack.Pop();
                }
            }, "non-generic");

            DoAndPrintDuration(() =>
            {
                var stack = new Stack<int>();
                for (int i = 0; i < Loops; i++)
                {
                    stack.Push(1);
                    int value = stack.Pop();
                }
            }, "generic");

            // Implicit conversion on types

            Money money = 12m;
            decimal amount = money;

            Console.WriteLine("{0}, {1}", money, amount);

            // Helper classes for converting

            var @byte = Convert.ToByte("0A", 16);
            Console.WriteLine(@byte);
            var @datetime = Convert.ToDateTime("20.09.1948");
            Console.WriteLine(@datetime);
            var @int = int.Parse("42");
            int.TryParse("42", out @int);

            // IFormattable
            var money2 = new Money(12.34m);
            Console.WriteLine("{0}", money2);

            // is and as
            object o = new MemoryStream();
            if (o is MemoryStream) { }
            MemoryStream ms = o as MemoryStream;

            // dynamic
            dynamic myDynamic = new MyDynamic();
            Console.WriteLine(myDynamic.MyProperty);

            // Access modifiers

            // Explicit interface implementation
            var robot = new Robot();
            //(robot as ILeft).Turn();
            //(robot as IRight).Turn();
        }

        private static void DoAndPrintDuration(Action action, string label = "")
        {
            var sw1 = new Stopwatch();
            sw1.Start();
            action();
            sw1.Stop();
            Console.WriteLine("{0}: {1} ms", label, sw1.ElapsedMilliseconds);
        }

        class MyNestedClass
        {
            MyNestedClass() { }

            public MyNestedClass(string message) : this() { }
        }

        interface IInterface { }
    }

    internal class MyBaseClass
    {
        int _field = 1;

        public string Property { get; private set; }
    }

    class MyDerivedClass : MyBaseClass
    {
        protected internal int _otherField = 2;

        internal void Method() { }
    }

    interface IInterface { }

    interface ILeft
    {
        void Turn();
    }

    interface IRight
    {
        void Turn();
    }

    class Robot : ILeft, IRight
    {
        void ILeft.Turn()
        {
            throw new NotImplementedException();
        }

        void IRight.Turn()
        {
            throw new NotImplementedException();
        }
    }
}