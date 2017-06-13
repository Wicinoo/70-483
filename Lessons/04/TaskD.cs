using System;

namespace Lessons._04
{
    public class YourOwnCustomException : Exception { }

    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        

        public static void Run()
        {
            ReadFile("");
        }

        public static void ReadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new YourOwnCustomException();
            }

            //some other important stuff
        }
    }
}