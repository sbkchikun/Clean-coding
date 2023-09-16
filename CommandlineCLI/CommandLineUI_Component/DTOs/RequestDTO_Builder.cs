
namespace DTOs
{
    public class RequestDTO_Builder
    {
        private int Command;
        private int Memberid;
        private int Bookid;
        private string Client;

        public RequestDTO Build()
        {
            return
                new RequestDTO(Command, Memberid, Bookid,Client);
        }

        public RequestDTO_Builder WithCommand(int command)
        {
            this.Command = command;
            return this;
        }

        public RequestDTO_Builder WithMemberId(int memberid)
        {
            this.Memberid = memberid;
            return this;
        }
        public RequestDTO_Builder WithClient(string client)
        {
            this.Client = client;
            return this;
        }

        public RequestDTO_Builder WithBookId(int bookid)
        {
            this.Bookid = bookid;
            return this;
        }

    }
}
