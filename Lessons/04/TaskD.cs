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
        public static void Run()
        {
            try
            {
                var myEmail = new Email("myEmail@AtGmailDotcom");
            }
            catch (InvalidEmailException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
        {
        }

        public InvalidEmailException(string message) : base(message)
        {
        }

        public InvalidEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class Email
    {
        private string _email;

        public Email(string email)
        {
            if (!email.Contains(".") || !email.Contains("@"))
            {
                throw new InvalidEmailException("Invalid email structure exception has been thrown");
            }

            _email = email;
        }
    }
}