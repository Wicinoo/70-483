using System;

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
                ThrowEx1();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception 1(throw ex;):");
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                ThrowEx2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception 2(throw;):");
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void ThrowEx1()
        {
            try
            {
                divideByZero();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ThrowEx2()
        {
            try
            {
                divideByZero();
            }
            catch
            {
                throw;
            }
        }

        private static int divideByZero()
        {
            var a = 0;
            return 1 / a;                
        }
    }
}