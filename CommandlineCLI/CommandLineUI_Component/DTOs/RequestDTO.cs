using System;
namespace DTOs
{
    [Serializable]
    public class RequestDTO : IDto
    {
        public int Command { get; }
        public int MemberId { get; }
        public int BookId { get; }
        public string Client { get; }

        public RequestDTO(int command, int memberid, int bookid,string client)
        {
            this.Command = command;
            this.MemberId = memberid;
            this.BookId = bookid;
            this.Client = client;

           
        }
    }
}
