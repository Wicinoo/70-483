using System;

namespace Lessons._04
{
    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            try
            {
                CheckTime();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CheckTime()
        {
            for (int i = 50; i > 0; i--)
            {
                if (i < 30)
                {
                    throw new NotEnoughTimeExcpetion("Not enough time to finish assignment.");
                }
            }
        }
    }

    public class NotEnoughTimeExcpetion : Exception
    {
        public NotEnoughTimeExcpetion(string msg) : base(msg)
        {

        }
    }
}