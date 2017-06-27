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
                Throw();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                ThrowException();
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2);
            }
        }

        public static void Throw()
        {
            try
            {
                DivideByZero();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ThrowException()
        {
            try
            {
                DivideByZero();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void DivideByZero()
        {
            int x = 0;
            int y = 1 / x;
        }
    }
}