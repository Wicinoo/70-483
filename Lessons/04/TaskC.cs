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
                try
                {
                    DivideByZero(10);
                }
                catch (DivideByZeroException exception)
                {
                    throw;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw exception;
            }
        }

        public static void DivideByZero(int i)
        {
            int j = 0;
            int k = i / j;
            Console.WriteLine(k);
        }
    }
}