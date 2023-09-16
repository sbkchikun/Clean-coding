using DTOs;
using Windows.Presenters;
using System.Windows.Controls;
namespace Windows.Commands
{
    class BorrowBookCommand : Command
    {
        private readonly int MemberId;
        private readonly int BookId;
        private readonly TextBox ConsoleBox;

        public BorrowBookCommand(int memberId, int bookId )
        {
            this.MemberId = memberId;
            this.BookId = bookId;
             
    }

        public RequestDTO Execute()
        {
           
            RequestDTO request = new RequestDTO_Builder().WithBookId(BookId).WithMemberId(MemberId).WithCommand(1).Build();

            return request;
        }
    }
}
