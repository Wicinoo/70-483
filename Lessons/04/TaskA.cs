using System;
using System.Collections;
using System.Reflection;

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
                InnerException();
            }
            catch (Exception ex)
            {   
                Console.WriteLine("Exception with inner exception caught.");
                PrintExceptionDetails(ex);
            }

            try
            {
                DataException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data exception caught.");
                PrintExceptionDetails(ex);
            }
        }

        public static void InnerException()
        {
            var e = new Exception("This statement is the original exception message.",
                new Exception("This statement is inner exception message"));

            throw e;
        }

        public static void DataException()
        {
            var e = new Exception("This statement is the original exception message.");

            var info = "Data exception data";
            var errorCode = -875;
            var thrown = DateTime.Now;
            e.Data.Add("DataException", info);
            e.Data["ErrorCode"] = errorCode;
            e.Data["DateTimeInfo"] = thrown;

            throw e;
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            var properties = exception.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                var value = propertyInfo.GetValue(exception, null) ?? "(null)";
                Console.WriteLine("[{0}]:[{1}]", propertyInfo.Name, value);
            }
        }
    }
}
