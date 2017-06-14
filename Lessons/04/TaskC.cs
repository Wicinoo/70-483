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
                SubMethodThrows();
            }
            catch (Exception e)
            {                
                Console.WriteLine("Using Throw :");
                Console.WriteLine(e.StackTrace);
            }

            try
            {
                SubMethodThrowException();
            }
            catch (Exception e)
            {
                Console.WriteLine("Using Throw Exception :");
                Console.WriteLine(e.StackTrace);
            }
        }


        private static void SubMethodCore()
        {
            var someThing = int.Parse("abcd");
        }

        private static void SubMethodOne()
        {
            SubMethodCore();
        }

        private static void SubMethodThrows()
        {
            try
            {
                SubMethodOne();
            }
            catch (Exception)
            { 
                throw;
            }
        }

        private static void SubMethodThrowException()
        {
            try
            {
                SubMethodOne();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}