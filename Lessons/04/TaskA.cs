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
                DivideNumber(100, 0);
            }
            catch(Exception ex)
            {
                PrintExceptionDetails(ex);
            }
        }

        private static int DivideNumber(int number, int dividor)
        {
            try
            {
                return number / dividor;
            }
            catch(DivideByZeroException ex)
            {
                var exception =  new ApplicationException("DivideNumber method threw exeption.", ex);
                exception.Data.Add("Number", number);
                exception.Data.Add("Dividor", dividor);
                throw exception;
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach(PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(exception))
            {
                Console.WriteLine($"[{propertyDescriptor.Name}]: [{propertyDescriptor.GetValue(exception)}]");
            }

            if(exception.Data.Count > 0)
            {
                Console.WriteLine("\nData dictionary:\n");
                foreach(DictionaryEntry item in exception.Data)
                {
                    Console.WriteLine($"[{item.Key}]: [{item.Value}]");
                }
            }
        }
    }
}
