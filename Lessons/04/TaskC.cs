using System;
using System.ComponentModel;

namespace Lessons._04
{
    public class YouCantBuyMeHotDogMan : Exception { };

    public class HappyBirthdayToTheGround : Exception { };

    public class IThrewTheRestOfTheCakeToo : Exception { };
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
                IThrewItOnTheGround();
            }
            catch(Exception ex) {
                PrintExceptionDetails(ex);
            }

            try
            {
                SomePoserHandsMeCakeAtABirthdayParty();
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
        }

        public static void IThrewItOnTheGround()
        {
            try
            {
                throw new YouCantBuyMeHotDogMan();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void SomePoserHandsMeCakeAtABirthdayParty()
        {
            try
            {
                throw new IThrewTheRestOfTheCakeToo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void PrintExceptionDetails(Exception exception)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(exception))
            {
                Console.WriteLine("{0}: {1}", descriptor.Name, descriptor.GetValue(exception));
            }
        }
    }
}