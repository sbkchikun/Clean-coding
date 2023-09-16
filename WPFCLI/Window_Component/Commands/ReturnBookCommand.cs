
using DTOs;
using System.Windows.Controls;
namespace Windows.Commands
{
    class ReturnBookCommand : Command
    {
        private readonly int MemberId;
        private readonly int BookId;
        private readonly TextBox ConsoleBox;

        public ReturnBookCommand(int memberId, int bookId )
        {
            this.MemberId = memberId;
            this.BookId = bookId;
             
        }

        public RequestDTO Execute()
        {
             
                RequestDTO request = new RequestDTO_Builder().WithBookId(BookId).WithMemberId(MemberId).WithCommand(2).Build();
                return request;
 
        }
    }
}
