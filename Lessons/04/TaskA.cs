using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lessons._04
{
    /// <summary>
    /// Write a method to print a structured listing of all properties of an exception. 
    /// Keep format [property_name]: [value]\n.
    /// Let your code throw an exception, handle it and use the method for printing.
    /// Simulate a situation with valid InnerException.
    /// Simulate a situation with non-empty Data dictionary.
    /// </summary>
    public static class TaskA
    {
        public static void Run()
        {
            try
            {
                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception innerex)
                {
                    innerex.Data.Add("First", "Inner exception.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("MyError", "It happens.");
                PrintExceptionDetails(ex);
            }

        }

        private static void PrintExceptionDetails(Exception exception)
        {
            Console.WriteLine("[Message]: [{0}]", exception.Message);
            Console.WriteLine("[StackTrace]: [{0}]", exception.StackTrace);
            Console.WriteLine("[HelpLink]: [{0}]", exception.HelpLink);
            Console.WriteLine("[InnerException]: [{0}]", exception.InnerException);
            Console.WriteLine("[TargetSite]: [{0}]", exception.TargetSite);
            Console.WriteLine("[Source]: [{0}]", exception.Source);
            foreach (DictionaryEntry dataItem in exception.Data)
            {
                Console.WriteLine("[Data]: [{0} : {1}]", dataItem.Key,dataItem.Value);
            }
        }
    }
}
