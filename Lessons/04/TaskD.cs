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
                var digit = ReadInput();
                var response = digit == 3 ? " " : " not ";

                Console.WriteLine($"This digit is{response}my favourite digit");
            }
            catch (InvalidInputException ie)
            {
                Console.WriteLine("Oops, that's not a digit");
            }
        }

        private static int ReadInput()
        {
            Console.Write("Enter your favourite digit: ");
            var input = Console.ReadKey();
            Console.WriteLine();

            try
            {
                var number = int.Parse(input.KeyChar.ToString());
                return number;
            }
            catch (FormatException fe)
            {
                var ie = new InvalidInputException("The character is not a valid number", fe);
                ie.Data.Add("keyPressed", input.KeyChar);
                throw ie;
            }
        }

        private class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message)
            {
            }

            public InvalidInputException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}