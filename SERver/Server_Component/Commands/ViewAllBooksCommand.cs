using Controllers;
using Presenters;

namespace CommandLineUI.Commands
{
    class ViewAllBooksCommand : Command
    {

        public ViewAllBooksCommand()
        {
        }

        public async Task<CommandLineViewData> Execute()
        {
            ViewAllBooksController controller =
                new ViewAllBooksController(
                        new AllBooksPresenter());

            return (CommandLineViewData)controller.Execute();
        }
    }
}
