
using DTOs;
using System.Windows.Controls;
namespace Windows.Commands
{
    class RenewLoanCommand : Command
    {
        private readonly int MemberId;
        private readonly int BookId;
         
        public RenewLoanCommand(int memberId, int bookId )
        {
            this.MemberId = memberId;
            this.BookId = bookId;
             
        }

        public RequestDTO Execute()
        {
            RequestDTO request = new RequestDTO_Builder().WithBookId(BookId).WithMemberId(MemberId).WithCommand(3).Build();
            return request;
        }
    }
}
