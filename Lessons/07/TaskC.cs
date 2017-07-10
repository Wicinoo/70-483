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

            using (var file = new FileWriter(FileName))
            {
                file.Write("I love C# certification trainings.");
            }
        }

        class FileWriter : IDisposable
        {
            private readonly string _fileName;
            private readonly StreamWriter _fileStream;
            
            public FileWriter(string fileName)
            {
                _fileName = fileName;
                _fileStream = File.CreateText(_fileName);
                Console.WriteLine($"File {_fileName} has been created.");
            }

            public void Write(string text)
            {
                _fileStream.Write(text);
            }

            public void Dispose()
            {
                _fileStream.Flush();
                _fileStream.Close();
                File.Delete(_fileName);
            }
        }
    }
}