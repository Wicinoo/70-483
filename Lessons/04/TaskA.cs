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
                throw new AccessViolationException("All your base belong to us!");
            }
            catch (Exception deep)
            {
                try
                {
                    deep.Data.Add("UserViolated", 8254);
                    throw new ArithmeticException("Error when calculating users market value.", deep);
                }
                catch (Exception shallow)
                {
                    shallow.Data.Add("ArithemticOperationFailed", "Division");
                    PrintExceptionDetails(shallow);
                }
            }
        }

        public static void PrintExceptionDetails(Exception exception)
        {
            foreach (PropertyInfo property in exception.GetType().GetProperties())
            {
                if (property.Name.Equals("Data"))
                {
                    foreach (DictionaryEntry row in exception.Data)
                    {
                        Console.WriteLine($"{row.Key}: {row.Value}");
                    }                    
                }
                else if(property.Name.Equals("InnerException") && exception.InnerException != null)
                {
                    PrintExceptionDetails((Exception) property.GetValue(exception));
                }
            }
        }
    }
}
