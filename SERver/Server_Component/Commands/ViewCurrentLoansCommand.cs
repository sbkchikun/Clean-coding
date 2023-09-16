using Controllers;
 
using Presenters;

namespace CommandLineUI.Commands
{
    class ViewCurrentLoansCommand : Command
    {

        public ViewCurrentLoansCommand()
        {
        }

        public async Task<CommandLineViewData> Execute()
        {
            ViewCurrentLoansController controller =
                new ViewCurrentLoansController(
                        new CurrentLoansPresenter());

            return (CommandLineViewData)controller.Execute();

        }
    }
}
