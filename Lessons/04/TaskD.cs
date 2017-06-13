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
                PrintOnlyIfEvenNumber(2);
            }
            catch (NotEvenNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void PrintOnlyIfEvenNumber(int number)
        {
            if (number % 2 != 0)
            {
                throw new NotEvenNumberException("Exteption: This is not even number.");
            }
            else
            {
                Console.WriteLine($"Number entered: {number}");
            }
        }
    }

    [Serializable]
    public class NotEvenNumberException : Exception, ISerializable
    {
        public NotEvenNumberException(string message)
            : base(message)
        {
        }
    }
}