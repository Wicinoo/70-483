using System;

namespace Lessons._04
{
    public static class _03_RethrowingException
    {
        public static void Run()
        {
            try
            {
                int.Parse("NaN");
            }
            catch (FormatException exception)
            {
                Console.WriteLine("An FormatException was caught.");

                // Uncomment to check differences
                //throw;

                throw exception;
            }
        }
    }
}