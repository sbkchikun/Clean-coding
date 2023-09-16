using Controllers;
using DTOs;
using Presenters;
using System.Text.Json;

namespace CommandLineUI.Commands
{
    class ViewCurrentLoansCommandWPF : CommandWPF
    {

        public ViewCurrentLoansCommandWPF()
        {
        }

        public async Task<string> Execute()
        {
            ViewCurrentLoansController controller =
                new ViewCurrentLoansController(
                        new CurrentLoansPresenterWPF());
            CurrentLoansViewData data =
                           (CurrentLoansViewData)controller.Execute();
            return "L" + JsonSerializer.Serialize(data);
        }
    }
}
