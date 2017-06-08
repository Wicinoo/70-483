using System;

namespace Lessons._04
{
    /// <summary>
    /// Write a code that demonstrates differences between 
    /// "throw;" and "throw exception;" in catch block.
    /// </summary>
    public class TaskC
    {
        // throw;
        // Stack Trace :
        //at Lessons._04.TaskC.JustThrow() in C:\Users\Ozan\Documents\GitHub\70-483\Lessons\04\TaskC.cs:line 47
        //at Lessons._04.TaskC.AnotherThrow() in C:\Users\Ozan\Documents\GitHub\70-483\Lessons\04\TaskC.cs:line 35
        //at Lessons._04.TaskC.Run() in C:\Users\Ozan\Documents\GitHub\70-483\Lessons\04\TaskC.cs:line 16

        //throw exception;
        //at Lessons._04.TaskC.AnotherThrow() in C:\Users\Ozan\Documents\GitHub\70-483\Lessons\04\TaskC.cs:line 42
        //at Lessons._04.TaskC.Run() in C:\Users\Ozan\Documents\GitHub\70-483\Lessons\04\TaskC.cs:line 23

        public static void Run()
        {
            try
            {
                AnotherThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void AnotherThrow()
        {
            try
            {
                JustThrow();
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }

        private static void JustThrow()
        {
            try
            {
                throw new ArithmeticException("Cannot calculate 2 x 2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}