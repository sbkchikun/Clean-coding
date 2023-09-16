using Controllers;
using Presenters;

namespace CommandLineUI.Commands
{
    class RenewLoanCommand : Command
    {
        private int memberid;
        private int bookid;
        public RenewLoanCommand(int memberid, int bookid)
        {
            this.memberid = memberid;
            this.bookid = bookid;
        }

        public async Task<CommandLineViewData> Execute()
        {
            RenewLoanController controller = 
                new RenewLoanController(
                    memberid
                    , bookid, 
                    new MessagePresenter());

            return (CommandLineViewData)controller.Execute();
        }
    }
}
