using System;

namespace Lessons._04
{
    public static class _02_MostImportantExceptionTypes
    {
        public static void Run()
        {
            // Don't use Exception type directly.
            new Exception("Something wrong happened.");

            new ArgumentException("Invalid parameter.");
            new ArgumentNullException("param");
            new ArgumentOutOfRangeException("param", "Parameter out of range.");

            new InvalidCastException("It is not able to cast from ... to ...");

            new IndexOutOfRangeException("Index is out of range.");

            new InvalidOperationException("Invalid context of operation.");

            new FormatException("Invalid format.");

            new ApplicationException();

            new NullReferenceException();

            new ObjectDisposedException("Object has been disposed yet.");

            // Don't handle these exception types.
            new StackOverflowException();
            new OutOfMemoryException();

            new NotImplementedException();
        }
    }
}