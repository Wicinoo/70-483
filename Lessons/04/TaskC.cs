using System;

namespace Lessons._04
{
    /// <summary>
    /// Write a code that demonstrates differences between 
    /// "throw;" and "throw exception;" in catch block.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            try
            {

                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
            }
            try
            {

                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
            }
        }
    }
}