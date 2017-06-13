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
            var input = Guid.NewGuid().ToString().ToUpper();
            try
            {
                if (input.Contains("A"))
                    throw new RestrictedSymbolsException(input);
            }
            catch (RestrictedSymbolsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    [Serializable]
    public class RestrictedSymbolsException : Exception, ISerializable
    {
        public string Input { get; set; }

        public override string Message
        {
            get
            {
                return "Input contains restricted characters";
            }
        }

        public RestrictedSymbolsException(string input)
        {
            Input = input;
        }

        public RestrictedSymbolsException(string input, string message) : base(message)
        {
            Input = input;
        }

        protected RestrictedSymbolsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Input = (string)info.GetValue("Input", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Input", Input, typeof(string));
        }
    }
}