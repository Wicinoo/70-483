using System;
using System.Net.NetworkInformation;

namespace Lessons._04
{
    /// <summary>
    /// Write a code that demonstrates differences between 
    /// "throw;" and "throw exception;" in catch block.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            try
            {
                ExThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                ExThrowEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void ExThrow()
        {
            try
            {
                ThrowSomeEx();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void ExThrowEx()
        {
            try
            {
                ThrowSomeEx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ThrowSomeEx()
        {
            throw new ArgumentNullException();
        }
    }
}