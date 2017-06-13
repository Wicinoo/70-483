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
            var sasha = new Sasha();
            try
            {
                sasha.isInTheOfficeNotifier();
            }
            catch (SashaIsNotInTheOfficeException ex)
            {
                Console.WriteLine("SashaIsNotInTheOfficeException: {0}", ex.Message);
            }
        }

        public class SashaIsNotInTheOfficeException : Exception
        {
            public SashaIsNotInTheOfficeException(string message) : base(message)
            {                
            }
        }

        public class Sasha
        {
            private bool isInTheOffice;

            public void isInTheOfficeNotifier()
            {
                if (isInTheOffice)
                {
                    Console.WriteLine("Sasha is in the office");
                }
                else
                {
                    throw new SashaIsNotInTheOfficeException("Sasha is not in the office - no release tomorrow.");  
                }
            }
        }
    }
}