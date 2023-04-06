using System;

namespace DTOs
{
    [Serializable]
    public class MessageDTO : DTO
    {
        public string Message { get; }

        public MessageDTO(string msg)
        {
            this.Message = msg;
        }
    }
}
