using System;
using System.Collections.Generic;
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
                throw new ArgumentException();
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }

            try
            {
               throw new ArgumentException("Exception 2", new ArgumentException("Exception1"));
                
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e.InnerException);
            }

            try
            {
                Dictionary<int, int> dic = new Dictionary<int, int>();
                dic.Add(1, 1);
                dic.Add(1, 1);
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
            
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(exception))
            {
                Console.WriteLine("[{0}]: [{1}]",descriptor.Name,descriptor.GetValue(exception));
            }
        }
    }
}
