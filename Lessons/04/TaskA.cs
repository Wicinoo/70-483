using System;
using System.Collections.Generic;
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
        [Serializable]
        public class NotANumberException : Exception
        {
            public NotANumberException(string message, object functionArgument, Exception innerException) 
                : base(message, innerException)
            {
                PopulateDataProperty(functionArgument);
            }

            private void PopulateDataProperty(object functionArgument)
            {
                Data.Add("Function Argument", functionArgument.ToString());
                // only for demo purposes
                Console.WriteLine(Data["Function Argument"]);
            }
        }

        public static void Run()
        {
            var stringToParse = "NaN";

            try
            {
                Int32.Parse(stringToParse);
            }
            catch (Exception exception)
            {
                var NaNException = new NotANumberException(exception.Message, stringToParse, exception);
                PrintExceptionDetails(NaNException);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            var properties = exception.GetType().GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name + ": " + property.GetValue(exception));
            }
        }
    }
}
