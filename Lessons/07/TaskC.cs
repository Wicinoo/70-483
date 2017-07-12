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
            const string FileName = "c:\\temp\\tmp.txt";

            using (var file = new FileWriter(FileName))
            {
                file.Write("I love C# certification trainings.");
            }

            File.Delete(FileName);
        }

        class FileWriter : IDisposable
        {
            private StreamWriter _fileStream;

            public FileWriter(string fileName)
            {
                _fileStream = File.CreateText(fileName);
                Console.WriteLine($"File {fileName} has been created.");
            }

            public void Write(string text)
            {
                _fileStream.Write(text);
            }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    if (_fileStream != null)
                    {
                        _fileStream.Close();
                    }
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            ~FileWriter()
            {
               // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
               Dispose(false);
            }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}