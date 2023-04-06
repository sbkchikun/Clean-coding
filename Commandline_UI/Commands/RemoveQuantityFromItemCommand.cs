using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class RemoveQuantityFromItemCommand : Command
    {

        public RemoveQuantityFromItemCommand()
        {
        }

        public void Execute()
        {
            RemoveQuantityFromItemController controller = 
                new RemoveQuantityFromItemController(
                    ConsoleReader.ReadString("\nEmployee Name"),
                    ConsoleReader.ReadInt("\nItem ID"),
                    ConsoleReader.ReadInt("How many items would you like to remove?"),
                    new MessagePresenter());

            CommandLineViewData data = 
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
