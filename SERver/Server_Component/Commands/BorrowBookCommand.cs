using Controllers;
using Presenters;

namespace CommandLineUI.Commands
{
    class BorrowBookCommand : Command
    {
        private int memberid;
        private int bookid;
        public BorrowBookCommand(int memberid, int bookid)
        {
            this.memberid = memberid;
            this.bookid = bookid;
        }

        public async Task<CommandLineViewData> Execute()
        {
            BorrowBookController controller = 
                new BorrowBookController(memberid
                    ,bookid,
                    new MessagePresenter());

            return (CommandLineViewData)controller.Execute();
        }
    }
}
