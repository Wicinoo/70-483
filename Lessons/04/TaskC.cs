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
                    FirstLayer();
                }
                catch (DivideByZeroException de)
                {
                    Console.WriteLine("I divided by zero! Let's rethrow with argument");
                    throw de;
                }
            }
            catch (DivideByZeroException de)
            {
                Console.WriteLine(de.StackTrace);
            }

            try
            {
                try
                {
                    FirstLayer();
                }
                catch (DivideByZeroException de)
                {
                    Console.WriteLine("I divided by zero! Let's rethrow without argument");
                    throw;
                }
            }
            catch (DivideByZeroException de)
            {
                Console.WriteLine(de.StackTrace);
            }
        }

        private static int FirstLayer()
        {
            return SecondLayer();
        }

        private static int SecondLayer()
        {
            return ThirdLayer();
        }

        private static int ThirdLayer()
        {
            var x = 0;
            return 1 / x;
        }
    }
}