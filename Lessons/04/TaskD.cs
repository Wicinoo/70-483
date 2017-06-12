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
                CheckCurrentDay();
            }
            catch (MondayException e)
            {
                Console.WriteLine("Monday exception");
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void CheckCurrentDay()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                throw new MondayException();
            }
        }
    }


    public class MondayException : Exception
    {
        public MondayException() : base() { this.HelpLink = "HelpLink is a lie."; }

        public MondayException(string message) : base(message) { this.HelpLink = "https://www.pizzazakki.cz/"; }
    }
}