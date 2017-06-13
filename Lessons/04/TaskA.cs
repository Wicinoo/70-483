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
        public static void Run() {
            try {
                throw new NotImplementedException("Well, somebody is definitely going to finish this...");
            } catch (Exception ex) {
                PrintExceptionDetails(ex);
            }

            try {
                ThrowWithInnerException();
            } catch (Exception ex) {
                PrintExceptionDetails(ex);
            }

        }

        private static void ThrowWithInnerException()
        {

            throw new Exception("The Cover", new NotSupportedException("The stuff"));
        }

        private static void PrintExceptionDetails(Exception exception) {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(exception)) {
                Console.WriteLine("{0}: {1}", descriptor.Name, descriptor.GetValue(exception));
            }
        }
    }
}
