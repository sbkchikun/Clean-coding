 
using DTOs;

namespace Windows.Commands
{
    class ViewAllBooksCommand : Command
    {

        public ViewAllBooksCommand()
        {
        }

        public RequestDTO Execute()
        {
            RequestDTO request = new RequestDTO_Builder().WithClient("WPF") .WithCommand(4).Build();
            return request;
        }
    }
}
