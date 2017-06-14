using System;
using System.Collections.Generic;
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
            var growthAssets = new HashSet<string> { "A", "B" };

            try
            {
                string isin = "C";

                if (!growthAssets.Contains(isin))
                {
                    throw new InvalidGrowthAssetException(isin);
                }
            }
            catch (InvalidGrowthAssetException e)
            {
                Console.WriteLine($"Following isin is not among Growth Assets: {e.Isin}");
            }
        }
    }

    [Serializable]
    public class InvalidGrowthAssetException : ApplicationException
    {
        public string Isin { get; private set; }

        public InvalidGrowthAssetException(string isin)
        {
            Isin = isin;
        }

        public InvalidGrowthAssetException(string isin, string message) : base(message)
        {
            Isin = isin;
        }

        public InvalidGrowthAssetException(string isin, string message, Exception inner) : base(message, inner)
        {
            Isin = isin;
        }

        protected InvalidGrowthAssetException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}