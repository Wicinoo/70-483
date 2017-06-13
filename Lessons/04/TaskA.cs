using System;
using System.Collections;
using System.ComponentModel;

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
                throw new Exception("first exception");
            }
            catch (Exception ex1)
            {
                try
                {
                    ex1.Data.Add("info1", "some info 1");
                    ex1.Data.Add("info2", "some info 2");
                    throw new Exception("second exception", ex1);
                }
                catch (Exception ex2)
                {
                    PrintExceptionDetails(ex2);
                }
            }
        }

        public static void PrintExceptionDetails(Exception exception)
        {
            foreach (var propertyInfo in exception.GetType().GetProperties())
            {
                if (propertyInfo.Name.Equals("InnerException", StringComparison.InvariantCultureIgnoreCase) && exception.InnerException != null)
                {
                    Console.WriteLine("Inner [[");
                    PrintExceptionDetails(exception.InnerException);
                    Console.WriteLine("]]");
                }
                else if (propertyInfo.Name.Equals("Data", StringComparison.InvariantCultureIgnoreCase))
                {
                    PrintExceptionData(exception.Data);
                }
                else
                {
                    PrintLine(propertyInfo.Name, propertyInfo.GetValue(exception)?.ToString());
                    //Console.WriteLine("{0}: {1}", propertyInfo.Name, propertyInfo.GetValue(exception));
                }
            }
        }

        private static void PrintExceptionData(IDictionary exceptionData)
        {
            foreach (var key in exceptionData.Keys)
            {
                PrintLine(key.ToString(), exceptionData[key].ToString());
            }
        }

        private static void PrintLine(string name, string value)
        {
            Console.WriteLine("{0}: {1}", name, value);
        }
    }
}
