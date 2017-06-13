using System;
using Xunit.Sdk;

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
                ThrowWithNewStack();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                ThrowWitOldStack();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void ThrowWithNewStack()
        {
            try
            {
                DivByZeroExceptionThrower();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Throwing new stack trace.");
                throw ex;
            }
        }

        public static void ThrowWitOldStack()
        {
            try
            {
                DivByZeroExceptionThrower();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Throwing old stack trace.");
                throw;
            }
        }

        private static void DivByZeroExceptionThrower()
        {
            var x = 0;
            var y = 1 / x;
        }
    }
}