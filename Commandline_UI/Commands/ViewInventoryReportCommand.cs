using Controllers;
using CommandLineUI.Presenters;
using System;
namespace CommandLineUI.Commands
{
    class ViewInventoryReportCommand : Command
    {

        public ViewInventoryReportCommand()
        {
            
        }

        public void Execute()
        {
            Console.WriteLine("Thus far");
            ViewInventoryReportController controller =
                new ViewInventoryReportController(
                        new InventoryReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
