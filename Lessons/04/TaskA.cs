using System;
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
            throw new NotImplementedException();
        }

        private void PrintExceptionDetails(Exception exception)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(exception))
            {
                Console.WriteLine("{0}: {1}", property.Name, property.GetValue(exception));
            }
        }
    }
}
