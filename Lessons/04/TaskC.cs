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
            Random rnd = new Random();
            var binary = rnd.Next(0, 2);
            try
            {
                if (binary == 0)
                {
                    ThrowWithoutStackTraceReset();
                } else
                {
                    ThrowWithStackTraceReset();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private static void ThrowWithStackTraceReset()
        {
            try
            {
                int.Parse("a"); ;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        private static void ThrowWithoutStackTraceReset()
        {
            try
            {
                int.Parse("b"); ;
            }
            catch (ArgumentException ex)
            {
                throw;
            }
        }
    }
}