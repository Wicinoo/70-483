using System;
using System.Collections;
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
        public static void Run()
        {
            try
            {
                try
                {
                    throw new Exception("My exception without inner one");
                }
                catch (Exception e)
                {
                    var newE = new Exception("This one contains inner", e);

                    newE.Data.Add("myKey", "myValue");

                    throw newE;
                }
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
        }

        private static void PrintExceptionDetails(Exception exception, int level = 0)
        {
            var props = exception.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in props)
            {
                var value = prop.GetValue(exception);

                Console.WriteLine($"{new string(' ', level * 5)}{prop.Name}: {value}");

                PrintValueAsException(value, level);

                PrintValueAsDictionary(value, level);
            }
        }

        private static void PrintValueAsException(object value, int level)
        {
            var exceptionValue = value as Exception;

            if (exceptionValue != null)
            {
                PrintExceptionDetails(exceptionValue, level + 1);
            }
        }

        private static void PrintValueAsDictionary(object value, int level)
        {
            var collectionValue = value as IDictionary;

            if (collectionValue != null)
            {
                foreach (DictionaryEntry item in collectionValue)
                {
                    Console.WriteLine($"{new string(' ', (level + 1) * 5)}{item.Key}: {item.Value}");
                }
            }
        }
    }
}
