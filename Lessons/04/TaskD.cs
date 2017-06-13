using System;

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
            var buffer = new Buffer();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    buffer.Push(i);
                }
            }
            catch (BufferFullException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    class Buffer
    {
        int[] _buffer = new int[2];
        int _pointer = 0;

        public void Push(int value)
        {
            if (_pointer < _buffer.Length)
            {
                _buffer[_pointer] = value;
                _pointer++;
            }
            else
            {
                throw new BufferFullException($"Unable to push value {value}");
            }
        }
    }

    class BufferFullException : Exception
    {
        public BufferFullException(string message) : base(message) { }
    }
}