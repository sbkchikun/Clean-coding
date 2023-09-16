using Controllers;
using Presenters;
 

namespace CommandLineUI.Commands
{
    class ViewAllMembersCommand : Command
    {

        public ViewAllMembersCommand()
        {
        }

        public async Task<CommandLineViewData> Execute()
        {
            ViewAllMembersController controller =
                new ViewAllMembersController(
                        new AllMembersPresenter());

            return (CommandLineViewData)controller.Execute();
        }
    }
}
