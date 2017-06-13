using System;
using System.Runtime.Serialization;

namespace Lessons._04
{
    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        private const int MinimalPensionAge = 55;

        public static void Run()
        {
            try
            {
                ValidateAge(20);
            }
            catch (AgeValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ValidateAge(int age)
        {
            if (age < MinimalPensionAge)
            {
                throw new AgeValidationException("Client is not old enough to take drawdown");
            }
        }

        public class AgeValidationException : Exception
        {
            public AgeValidationException()
            {
            }

            public AgeValidationException(string message) : base(message)
            {
            }

            public AgeValidationException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected AgeValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}