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
                ThrowMyException();
            }
            catch (MyException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void ThrowMyException()
        {
           throw new MyException("bla",new ArgumentException()); 
        }
    }

    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {}

        public MyException() { }

        public MyException(string message, Exception innerException) : base(message,innerException)
        { }

        public MyException(SerializationInfo info,StreamingContext context) : base(info,context)
        { }
    }
}