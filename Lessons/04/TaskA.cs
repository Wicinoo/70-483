using System;
using System.Collections;

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
                ThrowOuterException();
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
        }


        public static void ThrowInnerException()
        {
            var innerException = new ApplicationException("Throwing Inner Exception");
            innerException.Data.Add("DateTimeOfInnerExceptionThrown", DateTime.Now);
            throw innerException;
        }

        public static void ThrowOuterException()
        {
            try
            {
                ThrowInnerException();
            }
            catch (ApplicationException e)
            {
                var innerException = new ApplicationException("Throwing Outer Exception", e);
                innerException.Data.Add("DateTimeOfInnerExceptionCaught", DateTime.Now);
                throw innerException;
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            if (exception != null)
            {
                var properties = exception.GetType().GetProperties();

                foreach (var propertyInfo in properties)
                {

                    if (propertyInfo.PropertyType.Name == "IDictionary" && propertyInfo.GetValue(exception) != null)
                    {
                        Console.Write(propertyInfo.Name + " : ");
                        var dataDict = (IDictionary) propertyInfo.GetValue(exception);
                        foreach (var key in dataDict.Keys)
                        {
                            Console.Write(key.ToString() + "=" + dataDict[key] + " ");
                        }
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.WriteLine(propertyInfo.Name + " : " + Convert.ToString(propertyInfo.GetValue(exception)));
                    }
                }
            }
        }
    }
}
