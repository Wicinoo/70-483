using System;

namespace Lessons._04
{
    /// <summary>
    /// Write a code that demonstrates differences between
    /// "throw;" and "throw exception;" in catch block.
    /// </summary>
    public class TaskC
    {
        public static void OriginalThrower(string messageToThrow)
        {
            throw new Exception(messageToThrow);
        }

        public static void Run()
        {
            try
            {
                RethrowWithRestartOfStack();
            }
            catch (Exception e)
            {
                PrintException(e);
            }

            try
            {
                RethrowWithoutRestartOfStack();
            }
            catch (Exception e)
            {
                PrintException(e);
            }
        }

        private static void PrintException(Exception e)
        {
            Console.WriteLine($"{e.Message}");
            Console.WriteLine($"{e.StackTrace}");
        }


        public static void RethrowWithRestartOfStack()
        {
            try
            {
                OriginalThrower("Stack will be restarted");
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static void RethrowWithoutRestartOfStack()
        {
            try
            {
                OriginalThrower("Will keep the original stack");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}