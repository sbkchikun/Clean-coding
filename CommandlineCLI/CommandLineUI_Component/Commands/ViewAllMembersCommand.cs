using DTOs;
namespace CommandLineUI.Commands
{
    class ViewAllMembersCommand : Command
    {
         
        public ViewAllMembersCommand( )
        { 

        }

        public RequestDTO Execute()
        {
            
            RequestDTO request =  new RequestDTO_Builder()
                .WithCommand(5)
                .Build();
            return request;
            
        }
    }
}
