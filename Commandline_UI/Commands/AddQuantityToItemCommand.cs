using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class AddQuantityToItemCommand : Command
    {

        public AddQuantityToItemCommand()
        {
        }

        public void Execute()
        {
            AddQuantityToItemController controller = 
                new AddQuantityToItemController(
                    ConsoleReader.ReadString("\nEmployee Name"),
                    ConsoleReader.ReadInt("\nItem ID"),
                    ConsoleReader.ReadInt("Quantity to be added"),
                    ConsoleReader.ReadDouble("cost of item"),
                    new MessagePresenter());

            CommandLineViewData data = 
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
