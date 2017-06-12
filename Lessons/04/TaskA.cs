using System;
using System.Reflection;
using System.Text;

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
            //try
            //{
            //    Exception1();
            //}
            //catch (ArgumentException e)
            //{
            //    PrintExceptionDetails(e);
            //}

            try
            {
                InnerException();
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
                Console.WriteLine(e.InnerException.Data["ExtraInfo"]);
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        { 
            //https://stackoverflow.com/questions/4023462/how-do-i-automatically-display-all-properties-of-a-class-and-their-values-in-a-s
            PropertyInfo[] _PropertyInfos = null;
            _PropertyInfos = exception.GetType().GetProperties();
            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(exception, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            Console.WriteLine(sb);
        }

        private static void Exception1()
        {
            throw new ArgumentException("Arg not supplied");
        }

        private static void InnerException()
        {
            try
            {
                Exception1();
            }
            catch (Exception e)
            {
                e.Data["ExtraInfo"] = "Extra info added to the inner exception";
                throw new InvalidOperationException("InvalidOperation", e);
            }
        }
    }
}
