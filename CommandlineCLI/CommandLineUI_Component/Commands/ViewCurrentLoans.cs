using DTOs;
namespace CommandLineUI.Commands
{
    class ViewCurrentLoansCommand : Command
    { 
        public ViewCurrentLoansCommand( )
        {  
        }

        public RequestDTO Execute()
        {
            
            RequestDTO request =  new RequestDTO_Builder()
                .WithCommand(6)
                .Build();
            return request;
           

        }
    }
}
