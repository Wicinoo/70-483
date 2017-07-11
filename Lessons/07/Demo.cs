using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Lessons._07
{
    public class Demo
    {
        // Interfaces

        public interface IFoo
        {
            int FooProperty { get; set; }
            void FooMethod();
            int FooFunction();
            event Action FooEvent;
            int this[string index] { get; set; }
        }

        // Overriding virtual and non-virtual methods
        // Calling virtual member from ctor

        public class FooBase
        {
            public FooBase()
            {
                Console.WriteLine("FooBase constructor");
                PrintItself();    
            }

            public virtual void PrintItself()
            {
                Console.WriteLine("Hi, I'm FooBase");
            }
        }

        public class FooDerived : FooBase
        {
            public FooDerived()
            {
                Console.WriteLine("FooDerived constructor");
            }

            public override void PrintItself()
            {
                Console.WriteLine("Hi, I'm FooDerived");
            }
        }

        // Abstract class (vs. interface)

        public abstract class AbstractBar<FooBase>
        {
            public abstract string GiveMeYourName();

            public DateTime GiveMeCurrentDateTime()
            {
                return DateTime.Now;
            }
        }

        public class DerivedBar: AbstractBar<FooDerived>
        {
            public override string GiveMeYourName()
            {
                throw new NotImplementedException();
            }
        }

        // Sealed class

        public sealed class MyAttribute : Attribute { }

        // Standard .Net interfaces
        // IComparable[<T>] + <collection>.Sort()
        // IEnumerable[<T>]
        // IDisposable

        // Garbage Collector - mark and compact algorithm [all threads are frozen]
        // 1. marking all living items (those referenced by root items)
        // 2. moving all living items close together and releasing the remaining memory 
        // When GC starts collecting?
        // What is Generation 0?

        // Finalization
        // Examples of unmanaged resources: 
        // Open files, IntPtr, open network connections, unmanaged memory, bitmaps, ...

        public class FooWithManagedResources
        {
            private FileStream _file;

            public FooWithManagedResources()
            {
                _file = File.Create("myfile.doc");
            }

            ~FooWithManagedResources()
            {
                _file?.Dispose();
                _file = null;
                Console.WriteLine("~FooWithManagedResources");
            }
        }

        public class BarWithManagedAndUnmanagedResources : IDisposable
        {
            private FileStream _file;
            private IntPtr _handle;

            private bool _disposed = false;

            public BarWithManagedAndUnmanagedResources()
            {
                _file = File.Create("myfile.doc");
            }

            // Scenario A - called explicitly from code (using () {})
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            // Scenario B - called by GC
            ~BarWithManagedAndUnmanagedResources()
            {
                Dispose(false);
            }

            private void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    // Free unmanaged resources
                    ReleaseHandle(_handle);

                    if (disposing)
                    {
                        // Free managed resources
                        _file?.Dispose();
                        _file = null;
                    }

                    _disposed = true;
                }

                // base.Dispose() in case base class implements IDisposable
            }

            private void ReleaseHandle(IntPtr handle)
            {
                throw new NotImplementedException();
            }
        }

        public static void Run()
        {
            FooBase fb = new FooDerived();
            fb.PrintItself();

            // Enforcing collecting

            new FooWithManagedResources();
            GC.Collect();

            // WeakReference - simple caching (till GC starts next collecting)

            var data = new WeakReference(new object());
            var dataObject = data.Target;
        }
    }
} 