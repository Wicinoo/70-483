using System;
using System.IO;

namespace Lessons._07
{
    /// <summary>
    /// Improve implementation of TaskC and FileWriter 
    /// to release resources properly.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            const string FileName = "tmp.txt";

            using (var file = new FileWriter(FileName)) // using = ensure dispose will be allways called 
            {
                file.Write("I love C# certification trainings.");
            }
            
            File.Delete(FileName);
        }

        class FileWriter : IDisposable
        {
            private readonly StreamWriter _fileStream;

            public FileWriter(string fileName)
            {
                _fileStream = File.CreateText(fileName);
                Console.WriteLine($"File {fileName} has been created.");
            }

            public void Write(string text)
            {
                _fileStream.Write(text);
            }

            public void Dispose()
            {
                _fileStream.Dispose();
            }
        }
    }
}