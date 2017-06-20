using System;
using System.Collections.Generic;

namespace Lessons._05
{
    // SOLID

    class MyMessageHandler : IMessageHandler
    {
        public void Start()
        {
            var messageProvider = new MessageProvider();
            messageProvider.OnMessageReceived += HandleMessage;
        }

        public void Stop()
        {
            // It cannot be stopped! So ignore.
        }

        private void HandleMessage(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Information:
                    // Do something for information
                    break;
                case MessageType.Warning:
                    // Do something for warning
                    break;
                case MessageType.Error:
                    // Do something for error
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(message.Type), message.Type, null);
            }
        }
        
        public IEnumerable<Message> GetMessages()
        {
            // Not implemented yet
            throw new NotImplementedException();
        }
    }

    internal class MessageProvider
    {
        public event Action<Message> OnMessageReceived;
    }

    enum MessageType
    {
        Information,
        Warning,
        Error
    }

    struct Message
    {
        public MessageType Type { get; set; }
        public string Text { get; set; }
    }

    interface IMessageHandler : IStartable
    {
        IEnumerable<Message> GetMessages();
    }
    
    internal interface IStartable
    {
        void Start();
        void Stop();

    }
}