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
                string s = "s";
                int i = int.Parse(s);
                //Console.ReadKey();
            }
            catch (Exception e)
            {
                DateTime now = DateTime.Now;

                if (IsOdd(now.Second))
                {
                    throw e;
                }
                else
                {
                    // This option should be used when you don't want any modifications to the exception
                    throw;
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static bool IsOdd(int num)
        {
            if (num % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}