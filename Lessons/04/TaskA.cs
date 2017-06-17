using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;

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
                var x = ReadInput();
                Console.WriteLine(1/x);
            }
            catch (DivideByZeroException de)
            {
                PrintExceptionDetails(de);
            }
            catch (InvalidInputException ie)
            {
                PrintExceptionDetails(ie);
            }
        }

        private static int ReadInput()
        {
            Console.Write("Enter your favourite digit: ");
            var input = Console.ReadKey();
            Console.WriteLine();

            try
            {
                var number = int.Parse(input.KeyChar.ToString());
                return number;
            }
            catch (FormatException fe)
            {
                var ie = new InvalidInputException("The character is not a valid number", fe);
                ie.Data.Add("keyPressed", input.KeyChar);
                throw ie;
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            PrintPropertyDetails(exception.Data, nameof(exception.Data));
            PrintPropertyDetails(exception.HResult, nameof(exception.HResult));
            PrintPropertyDetails(exception.HelpLink, nameof(exception.HelpLink));
            PrintPropertyDetails(exception.InnerException, nameof(exception.InnerException));
            PrintPropertyDetails(exception.Message, nameof(exception.Message));
            PrintPropertyDetails(exception.Source, nameof(exception.Source));
            PrintPropertyDetails(exception.StackTrace, nameof(exception.StackTrace));
            PrintPropertyDetails(exception.TargetSite, nameof(exception.TargetSite));
        }

        private static void PrintPropertyDetails(object o, string name)
        {
            Console.WriteLine($"[{name}]: [{o}]");
        }

        private static void PrintPropertyDetails(IDictionary dictionary, string name)
        {
            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"[{name}]: [{key}: {dictionary[key]}]");
            }
        }

        private class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message)
            {
            }

            public InvalidInputException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
