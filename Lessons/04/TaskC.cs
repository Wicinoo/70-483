using System;
using System.IO;

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
            //try
            //{
            //    ReadAFile(string.Empty);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Stack trace shows exception is from ReadAFile");
            //    Console.WriteLine($"StackTrace: {ex.StackTrace}");
            //}

            try
            {
                ReadAFile2(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stack trace shows exception is from ReadAllLines");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

        }

        private static void ReadAFile(string fileName)
        {
            try
            {
                var result = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static void ReadAFile2(string fileName)
        {
            try
            {
                var result = File.ReadAllLines(fileName);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}