using System;
using System.Runtime.ExceptionServices;

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
                RunThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                RunThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void RunThrow()
        {
            try
            {
                GenerateException();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static void RunThrowException()
        {
            try
            {
                GenerateException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void GenerateException()
        {
            throw new NotImplementedException();
        }
    }
}