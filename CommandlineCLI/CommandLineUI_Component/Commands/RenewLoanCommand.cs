
using DTOs;


namespace CommandLineUI.Commands
{
    class RenewLoanCommand : Command
    {
        
        public RenewLoanCommand( )
        {
             
        }

        public RequestDTO Execute( )
        {
            
            RequestDTO request =  new RequestDTO_Builder()
                .WithCommand(3)
                .WithMemberId(ConsoleReader.ReadInt("\nMember ID"))
                .WithBookId(ConsoleReader.ReadInt("Book ID"))
                .Build();
            return request;
            
        }
    }
}
