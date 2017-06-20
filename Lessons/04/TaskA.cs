using System;

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
                throw new NotImplementedException("Missing implementation");
            }
            catch (NotImplementedException ex)
            {
                PrintExceptionDetails(ex);
            }

            try
            {
                throw new InvalidOperationException("This operation is not supported", new ArithmeticException("Cannot calculate this"));
            }
            catch (InvalidOperationException exception)
            {
                PrintExceptionDetails(exception);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (var property in exception.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(exception)}");
            }
        }
    }
}
