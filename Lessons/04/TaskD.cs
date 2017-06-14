using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
            TryCatchSerialize(null);
            TryCatchSerialize(new PostCodeInfo { CountryCode = "UK", PostCode = "001" });
            TryCatchSerialize(new PostCodeInfo { CountryCode = "UK" });
        }

        public static void TryCatchSerialize(PostCodeInfo postCodeInfo)
        {
            try
            {
                InspectPostCode(postCodeInfo);
            }
            catch (InvalidPostCodeException pce)
            {
                TaskA.PrintExceptionDetails(pce);
                MemoryStream ms = SerializeToStream(pce);
                InvalidPostCodeException pce2 = (InvalidPostCodeException)DeserializeFromStream(ms);
                TaskA.PrintExceptionDetails(pce2);
            }
        }

        public static void InspectPostCode(PostCodeInfo info)
        {
            if (info == null)
            {
                throw new InvalidPostCodeException("PostCode instance cannot be null", new ArgumentNullException(nameof(info)));
            }

            if (string.IsNullOrEmpty(info.CountryCode) || string.IsNullOrEmpty(info.PostCode))
            {
                throw new InvalidPostCodeException("Both CountryCode and PostCode must be specified.", info);
            }

            if (string.Equals(info.CountryCode, "UK", StringComparison.InvariantCultureIgnoreCase) && info.PostCode.Length != 6)
            {
                throw new InvalidPostCodeException("UK post code must have 6 characters.", info);
            }
        }

        public static MemoryStream SerializeToStream(object o)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream;
        }

        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object o = formatter.Deserialize(stream);
            return o;
        }
    }

    [Serializable]
    public class PostCodeInfo
    {
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
    }

    

    [Serializable]
    public class InvalidPostCodeException : Exception, ISerializable
    {
        public PostCodeInfo PostCodeInfo { get; set; }

        public InvalidPostCodeException()
        {
        }

        public InvalidPostCodeException(string message) : base(message)
        {
        }

        public InvalidPostCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPostCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.PostCodeInfo = (PostCodeInfo)info.GetValue("PostCodeInfo", typeof(PostCodeInfo));
        }

        public InvalidPostCodeException(PostCodeInfo postCodeInfo)
        {
            this.PostCodeInfo = postCodeInfo;
        }

        public InvalidPostCodeException(string message, PostCodeInfo postCodeInfo) : base(message)
        {
            this.PostCodeInfo = postCodeInfo;
        }

        public InvalidPostCodeException(string message, Exception innerException, PostCodeInfo postCodeInfo) : base(message, innerException)
        {
            this.PostCodeInfo = postCodeInfo;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("PostCodeInfo", this.PostCodeInfo, typeof(PostCodeInfo));
        }
    }
}