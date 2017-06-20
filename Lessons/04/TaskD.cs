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
                var result = DivideNumber(100, 0);
            }
            catch(MyCustomInvalidArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static decimal DivideNumber(decimal number, decimal dividor)
        {
            if(dividor.Equals(0))
            {
                throw new MyCustomInvalidArgumentException("Dividor can't be 0.");
            }

            return number / dividor;
        }
    }

    public class MyCustomInvalidArgumentException : Exception
    {
        public MyCustomInvalidArgumentException() : base()
        {
        }

        public MyCustomInvalidArgumentException(string message) : base(message)
        {
        }

        public MyCustomInvalidArgumentException(string message, Exception innerEx) : base(message, innerEx)
        {
        }
    }
}