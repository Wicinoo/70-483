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
            Console.WriteLine("-------- Test case - because we use throw exception, we will lost stack trace ---------");
            try
            {
                UseThrowException();
            }
            catch (Exception ex)
            {
                ExceptionPrinter.PrintExceptionDetails(ex);
            }

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("-------- Test case - throw, we will not lost stack trace ---------");
            try
            {
                UseThrow();
            }
            catch (Exception ex)
            {
                ExceptionPrinter.PrintExceptionDetails(ex);
            }


        }

        private static void UseThrowException()
        {
            try
            {
                DoSomethingWrong();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------- Original Exception ---------");
                ExceptionPrinter.PrintExceptionDetails(ex);
                throw ex;
            }
        }

        private static void UseThrow()
        {
            try
            {
                DoSomethingWrong();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------- Original Exception ---------");
                ExceptionPrinter.PrintExceptionDetails(ex);
                throw;
            }
        }


        private static void DoSomethingWrong()
        {
            int.Parse("asdfasf");
        }
    }
}