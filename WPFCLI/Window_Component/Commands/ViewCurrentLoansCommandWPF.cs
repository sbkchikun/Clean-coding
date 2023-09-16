
using DTOs;

namespace Windows.Commands
{
    class ViewCurrentLoansCommand : Command
    {

        public ViewCurrentLoansCommand()
        {
        }

        public RequestDTO Execute()
        {
            RequestDTO request = new RequestDTO_Builder().WithClient("WPF").WithCommand(6).Build();
            return request;
        }
    }
}
