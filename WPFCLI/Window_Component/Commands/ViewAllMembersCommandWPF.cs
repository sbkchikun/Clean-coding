 
using DTOs;

namespace Windows.Commands
{
    class ViewAllMembersCommand : Command
    {

        public ViewAllMembersCommand()
        {
        }

        public RequestDTO Execute()
        {
            RequestDTO request = new RequestDTO_Builder().WithClient("WPF").WithCommand(5).Build();
            return request;
        }
    }
}
