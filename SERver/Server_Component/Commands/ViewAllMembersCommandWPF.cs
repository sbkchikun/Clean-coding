using Controllers;
using DTOs;
using Presenters;
using System.Text.Json;

namespace CommandLineUI.Commands
{
    class ViewAllMembersCommandWPF : CommandWPF
    {

        public ViewAllMembersCommandWPF()
        {
        }

        public async Task<string> Execute()
        {
            ViewAllMembersController controller =
                new ViewAllMembersController(
                        new AllMembersPresenterWPF());
            WPFViewData<MemberDTO> data =
                           (WPFViewData<MemberDTO>)controller.Execute();
            return "M" + JsonSerializer.Serialize(data);
        }
    }
}
