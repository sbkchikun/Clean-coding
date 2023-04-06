using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ViewTransactionLogCommand : Command
    {

        public ViewTransactionLogCommand()
        {
        }

        public void Execute()
        {
            ViewTransactionLogController controller =
                new ViewTransactionLogController(
                        new TransactionLogPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
