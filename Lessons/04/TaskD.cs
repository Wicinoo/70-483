using System;
using System.Runtime.Serialization;

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
            var myDreamGarden = new Garden()
            {
                NumberOfDwarves = 5,
                NumberOfTrees = 0
            };
        }
    }

    public class Garden
    {
        private int _numberOfDwarves;
        public int NumberOfDwarves {
            get { return _numberOfDwarves; }
            set
            {
                if (value > 3)
                {
                    throw new TooManyDwarvesException("Maximum number of dwarves is 3");
                }

                _numberOfDwarves = value;
            }
        }

        public int NumberOfTrees { get; set; }
    }

    public class TooManyDwarvesException : Exception
    {
        public TooManyDwarvesException()
        {
        }

        public TooManyDwarvesException(string message) : base(message)
        {
        }

        public TooManyDwarvesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooManyDwarvesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}