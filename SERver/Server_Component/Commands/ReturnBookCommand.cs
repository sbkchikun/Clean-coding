using Controllers;
using  Presenters;

namespace CommandLineUI.Commands
{
    class ReturnBookCommand : Command
    {
        private int memberid;
        private int bookid;
        public ReturnBookCommand(int memberid,int bookid)
        {
            this.memberid = memberid;
            this.bookid = bookid;
        }

        public async Task<CommandLineViewData> Execute()
        {
            ReturnBookController controller = 
                new ReturnBookController(memberid
                    , bookid,
                    new MessagePresenter());
            return (CommandLineViewData)controller.Execute();
        }
    }
}
