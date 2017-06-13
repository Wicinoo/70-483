using System;
using System.IO;

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
            var fileName = "thisFileBetterWillNotExists.please";
            try
            {
                OpenFileStreamForReading(fileName);
            }
            catch (CustomMissingFileException)
            {
                Console.WriteLine($"File with name {fileName} was not found.");
            }
        }

        private static FileStream OpenFileStreamForReading(string fileName)
        {
            try
            {
                return File.Open(fileName, FileMode.Open);
            }
            catch (FileNotFoundException e)
            {

                throw new CustomMissingFileException(e);
            }

        }
    }
}