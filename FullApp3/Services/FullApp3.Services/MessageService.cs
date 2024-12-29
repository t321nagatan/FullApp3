using FullApp3.Services.Interfaces;

namespace FullApp3.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
