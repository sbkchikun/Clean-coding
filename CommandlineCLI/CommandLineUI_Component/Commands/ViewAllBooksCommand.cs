
using DTOs;
namespace CommandLineUI.Commands
{
    class ViewAllBooksCommand : Command
    {
         
        public ViewAllBooksCommand( )
        {
           
        }

        public RequestDTO Execute()
        {
            
            RequestDTO request =  new RequestDTO_Builder()
                .WithCommand(4)
                .Build();
            return request;
            
        }
    }
}
