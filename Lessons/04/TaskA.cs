using System.Runtime.Serialization;
using Lessons._04;
using System;
using System.Runtime.ExceptionServices;

namespace Lessons._04
{
    /// <summary>
    /// Write a method to print a structured listing of all properties of an exception. 
    /// Keep format [property_name]: [value]\n.
    /// Let your code throw an exception, handle it and use the method for printing.
    /// Simulate a situation with valid InnerException.
    /// Simulate a situation with non-empty Data dictionary.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            try
            {
                CatchInner();
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            Console.WriteLine("Message: {0}", exception.Message);
            Console.WriteLine("StackTrace: {0}", exception.StackTrace);
            Console.WriteLine("HelpLink: {0}", exception.HelpLink);
            Console.WriteLine("InnerException: {0}", exception.InnerException);
            Console.WriteLine("TargetSite: {0}", exception.TargetSite);
            Console.WriteLine("Source: {0}", exception.Source);
            Console.WriteLine("HResult: {0}", exception.HResult);
            Console.WriteLine("Data: {0}", exception.Data);
        }

        public static void ThrowInner()
        {
            throw new AppException("Exception in ThrowInner method.");
        }

        public static void CatchInner()
        {
            try
            {
                ThrowInner();
            }
            catch (AppException e)
            {
                throw new AppException("Error in CatchInner caused by calling the ThrowInner method.", e);
            }
        }
    }

    public class AppException : Exception
    {
        public AppException(String message) : base(message)
        { }
        public AppException(String message, Exception inner) : base(message, inner) { }
    }
}
