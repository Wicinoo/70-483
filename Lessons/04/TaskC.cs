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
            Console.WriteLine("Throw without throw ex:");
            try
            {
                ExampleThrow();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine();
            Console.WriteLine("Throw with throw ex:");
            try
            {
                ExampleThrowEx();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        public static void ExampleThrow()
        {
            try
            {
                GenerateException();
            } catch (Exception ex)
            {
                throw;
            }
        }

        public static void ExampleThrowEx()
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

        public static void GenerateException()
        {
            throw new ArgumentException();
        }
    }
}