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
            ThrowAndPrint(true);

            ThrowAndPrint(false);
        }

        private static void ThrowAndPrint(bool saveStackTrace)
        {
            try
            {
                Throw(saveStackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine($"SaveStackTrace: {saveStackTrace} Exception: {e}");
            }
        }

        private static void Throw(bool saveStackTrace)
        {
            try
            {
                throw new Exception("This is my exception. Look at stacktraces !");
            }
            catch (Exception e)
            {
                if (saveStackTrace)
                {
                    throw;
                }
                else
                {
                    throw e;
                }
            }
        }
    }
}