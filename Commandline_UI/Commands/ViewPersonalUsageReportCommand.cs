using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ViewPersonalUsageReportCommand : Command
    {

        public ViewPersonalUsageReportCommand()
        {
        }

        public void Execute()
        {
            ViewPersonalUsageReportController controller =
                new ViewPersonalUsageReportController(ConsoleReader.ReadString("\nEmployee Name"),
                        new PersonalUsageReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
