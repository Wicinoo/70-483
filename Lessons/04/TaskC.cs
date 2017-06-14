using System;
using System.ComponentModel;

namespace Lessons._04
{
    /// <summary>
    /// Write a code that demonstrates differences between 
    /// "throw;" and "throw ex;" in catch block.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            try
            {
                try
                {
                    ThrowEx();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

            try
            {
                try
                {
                    ThrowEx();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

            try
            {
                try
                {
                    ThrowEx();
                }
                catch (Exception e)
                {
                    throw new Exception("e", e);
                }
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
        }

        private static void ThrowEx()
        {
            throw new Exception("exc");
        }

        private static void PrintExceptionDetails(Exception ex)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(ex))
            {
                Console.WriteLine("{0}: {1}", property.Name, property.GetValue(ex));
            }
        }
    }
}
