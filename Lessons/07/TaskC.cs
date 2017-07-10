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

            var file = new FileWriter(FileName);
            file.Write("I love C# certification trainings.");

            file.Dispose();
        }

        interface IFileWriter : IDisposable
        {
            void Write(string text);
        }

        class FileWriter : IFileWriter
        {
            private readonly StreamWriter _fileStream;

            private readonly string _fileName;

            public FileWriter(string fileName)
            {
                _fileStream = File.CreateText(fileName);
                _fileName = fileName;

                Console.WriteLine($"File {fileName} has been created.");
            }

            public void Write(string text)
            {
                _fileStream.Write(text);
            }

            public void Dispose()
            {
                _fileStream.Close();

                try
                {
                    File.Delete(_fileName);
                }
                catch(IOException)
                {
                    Console.WriteLine("File is being used by another program.");
                }
            }
        }
    }
}