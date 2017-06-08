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
                throw new LameException(3,4);
            }
            catch (LameException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }

    public class LameException : ArithmeticException
    {
        private int _number1;

        private int _number2;

        public LameException(int number1, int number2)
        {
            _number1 = number1;
            _number2 = number2;
        }

        public override string ToString()
        {
            return string.Format("Cannot multiply : {0} x {1}", _number1, _number2);
        }
    }
}