using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        private static readonly BlockingCollection<Action> _filesQueue = new BlockingCollection<Action>();

        public static void Run()
        {
            // Set to false to demonstrate no thread-safety processing
            const bool ThreadSafetyProcessing = true;

            var files = new[] { "File1", "File2", "File3" };

            if (ThreadSafetyProcessing)
            {

                var threadForListeningToRequests = new Thread(RunUpload);
                threadForListeningToRequests.Start();

                Parallel.ForEach(files, UploadFileSequentially);

                Console.ReadKey();

                threadForListeningToRequests.Abort();
            }
            else
            {
                Parallel.ForEach(files, UploadFileDirectly);
            }
        }

        private static void UploadFileDirectly(string file)
        {
            NotThreadSafeFileUploader.UploadFile(file);
        }

        private static void UploadFileSequentially(string address)
        {
            var wasAddSuccessfull = _filesQueue.TryAdd(
                () => NotThreadSafeFileUploader.UploadFile(address));

            if (!wasAddSuccessfull) throw new InvalidOperationException("Problem with sending an email.");
        }

        private static void RunUpload()
        {
            Func<Action, bool> actionWithTrueResultWrapper = action =>
            {
                action();
                return true;
            };

            while (actionWithTrueResultWrapper(_filesQueue.Take())) { }
        }
    }

    internal static class NotThreadSafeFileUploader
    {
        private static bool _isUploading;

        public static void UploadFile(string fileName)
        {
            if (_isUploading)
            {
                throw new InvalidOperationException();
            }

            _isUploading = true;

            Thread.Sleep(1000);

            Console.WriteLine("File {0} has been uploaded.", fileName);

            _isUploading = false;
        }
    }
}