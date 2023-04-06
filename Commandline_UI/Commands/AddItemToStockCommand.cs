using Controllers;
using CommandLineUI.Presenters;
namespace CommandLineUI.Commands
{
    class AddItemToStockCommand : Command
    {

        public AddItemToStockCommand()
        {
        }

        public void Execute()
        {
            AddItemToStockController controller = 
                new AddItemToStockController(
                    ConsoleReader.ReadString("\nEmployee Name"),
                    ConsoleReader.ReadInt("Item ID"),
                    ConsoleReader.ReadString("Item Name"),
                    ConsoleReader.ReadInt("Quantity to be added"),
                    ConsoleReader.ReadDouble("cost of item"),
                    new MessagePresenter());

            CommandLineViewData data = 
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
