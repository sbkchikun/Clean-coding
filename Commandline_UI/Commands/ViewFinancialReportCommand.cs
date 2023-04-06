using Controllers;
using CommandLineUI.Presenters;

namespace CommandLineUI.Commands
{
    class ViewFinancialReportCommand : Command
    {

        public ViewFinancialReportCommand()
        {
            
        }

        public void Execute()
        {
            ViewFinancialReportController controller =
                new ViewFinancialReportController(
                        new FinancialReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
