using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            GetExceptionDelegate d = GetException;
            d += GetArgumentNullException;

            foreach (var del in d.GetInvocationList())
            {
                Exception ex = ((GetExceptionDelegate)del).Invoke();
                Console.WriteLine($"Exception type: {ex.GetType().Name}, message: {ex.Message}");
            }
        }

        

        public static Exception GetException()
        {
            return new Exception("General exception.");
        }

        public static ArgumentNullException GetArgumentNullException()
        {
            return new ArgumentNullException("someParam", "Specified parameter cannot be null.");
        }

        public delegate Exception GetExceptionDelegate();
    }
}