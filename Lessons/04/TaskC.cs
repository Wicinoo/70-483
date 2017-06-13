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
                HandleExceptionAndRethrowNew(null);
            }
            catch (Exception ex)
            {
                LogException(nameof(HandleExceptionAndRethrowNew), ex);
            }

            try
            {
                HandleExceptionAndRethrow(null);
            }
            catch (Exception ex)
            {
                LogException(nameof(HandleExceptionAndRethrow), ex);
            }
        }

        public static void LogException(string methodName, Exception ex)
        {
            bool found = ex.StackTrace.IndexOf(nameof(OriginalMethodThrowingException)) > -1;
            Console.WriteLine($"Method name: {methodName}, stack trace contains the original method that threw exception: {found}");
        }

        public static void HandleExceptionAndRethrowNew(string input)
        {
            try
            {
                OriginalMethodThrowingException(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void HandleExceptionAndRethrow(string input)
        {
            try
            {
                OriginalMethodThrowingException(input);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void OriginalMethodThrowingException(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input must be specified.");
            }
        }
    }
}