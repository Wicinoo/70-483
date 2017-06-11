using System;
using System.Collections;
using System.IO;

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
                throw new NotImplementedException();
            }
            catch (Exception inner)
            {
                try
                {
                    inner.Data.Add("Additional1", "My Additional information");
                    inner.Data["Additional2"] = "My another Additional information";
                    throw new FileNotFoundException("File for logging exception wasn't found", inner);
                }
                catch (Exception outter)
                {
                    PrintExceptionDetails(outter);
                }
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (var property in exception.GetType().GetProperties())
            {
                if (property.Name == "Data")
                {
                    PrintExceptionData(exception.Data);
                }
                else if (property.Name == "InnerException" && exception.InnerException != null)
                {
                    Console.WriteLine("[Inner Exception]: ");
                    PrintExceptionDetails((Exception) property.GetValue(exception));
                }
                else
                {
                    Console.WriteLine($"[{property.Name}]: {property.GetValue(exception)}");
                }

            }
        }

        private static void PrintExceptionData(IDictionary data)
        {
            if (data.Count > 0)
            {
                foreach (var key in data.Keys)
                {
                    Console.WriteLine($"[Data]: {key} : {data[key]}");
                }
            }

        }
    }
}
