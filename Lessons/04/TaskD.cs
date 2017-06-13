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
            Random rnd = new Random();
            int b = rnd.Next(1, 10);
            int a = rnd.Next(1, 10);
            try
            {
                var x = 1 / (a * b % 6);
            }
            catch (DivisibleBySixException ex)
            {

            }
        }
    }

    [Serializable]
    public class DivisibleBySixException : Exception, ISerializable
    {
        public DivisibleBySixException() { }
    }
}