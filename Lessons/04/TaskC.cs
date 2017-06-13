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
                var x = StringToInt("you will parse this string into int just in your dreams");
            }
            catch(Exception e)
            {
                Console.WriteLine("[StackTrace]: [{0}]", e.StackTrace);
            }

            try
            {
                var x = StringToInt2("you will parse this string into int just in your dreams");
            }
            catch (Exception e)
            {
                Console.WriteLine("[StackTrace]: [{0}]", e.StackTrace);
            }

        }

        public static int StringToInt(string s)
        {
            try
            {
                return int.Parse("NaN");
            }
            catch (FormatException exception)
            {
                Console.WriteLine();
                Console.WriteLine("Same exception with new stacktrace has been thrown");
                throw exception;
            }
        }

        public static int StringToInt2(string s)
        {
            try
            {
                return int.Parse("NaN");
            }
            catch (FormatException exception)
            {
                Console.WriteLine();
                Console.WriteLine("original exception was rethrown");

                throw;
            }
        }
    }
}