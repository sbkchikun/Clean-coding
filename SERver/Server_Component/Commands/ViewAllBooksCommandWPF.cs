using Controllers;
using System.Text.Json;
using Presenters;
using DTOs;

namespace CommandLineUI.Commands
{
    class ViewAllBooksCommandWPF : CommandWPF
    {

        public ViewAllBooksCommandWPF()
        {
        }

        public async Task<string> Execute()
        {
            ViewAllBooksController controller =
                new ViewAllBooksController(
                        new AllBooksPresenterWPF());

            WPFViewData<BookDTO> data =
                (WPFViewData<BookDTO>)controller.Execute();

            return "B" + JsonSerializer.Serialize(data);
        }
    }
}
