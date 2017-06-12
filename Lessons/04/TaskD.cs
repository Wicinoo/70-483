using System;

namespace Lessons._04
{
    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        [Serializable]
        public class NotANumberException : Exception
        {
            public NotANumberException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }

        public static void Run()
        {
            try
            {
                Int32.Parse("NaN");
            }
            catch (Exception exception)
            {
                 throw new NotANumberException(exception.Message, exception);
            }
        }
    }
}