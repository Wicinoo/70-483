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
                throw new SomeCustomException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
        }
    }

    public class SomeCustomException : Exception
    {

    }
}