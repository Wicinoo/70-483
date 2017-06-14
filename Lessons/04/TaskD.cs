using System;
using System.Collections.Generic;

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
            var processingStuff = new ProcessingList(20);

            try
            {
                for (int i = 0; i < 40; i++)
                {
                    processingStuff.AddProcessing(i);
                }
            }
            catch (ProcessingListFullException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.GetType() + " thrown " + e.Message);
                Console.ReadKey();
            }
        }
    }

    public class ProcessingList
    {
        private List<int> _list;

        private int _capacity;

        public ProcessingList(int capacity)
        {
            _capacity = capacity;
            _list = new List<int>();
        }

        public void AddProcessing(int processing)
        {
            _list.Add(processing);
            if (_list.Count > _capacity)
            {
                throw new ProcessingListFullException("ProcessingListFull");
            }
        }

    }
    [Serializable]
    public class ProcessingListFullException : Exception
    {
        public ProcessingListFullException(string message) : base(message)
        { }

        public ProcessingListFullException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}