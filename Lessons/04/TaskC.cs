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
                    ThrowException();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            try
            {
                try
                {
                    ThrowException();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        public static void ThrowException()
        {
            throw new ArgumentException("Exception");
        }
    }
}