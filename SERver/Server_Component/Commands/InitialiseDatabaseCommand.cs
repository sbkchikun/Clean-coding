using Controllers;
using Presenters;
using ServerSide;

namespace CommandLineUI.Commands
{
    class InitialiseDatabaseCommand : Command
    {

        public InitialiseDatabaseCommand()
        {
        }

        public async Task<CommandLineViewData> Execute()
        {
            InitialiseDatabaseController controller =
                new InitialiseDatabaseController(
                        new MessagePresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

             ConsoleWriter.WriteStrings(data.ViewData);
            return null;
        }
    }
}
