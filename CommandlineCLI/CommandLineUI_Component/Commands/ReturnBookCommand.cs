
using DTOs;
namespace CommandLineUI.Commands
{
    class ReturnBookCommand : Command
    {
        
        public ReturnBookCommand( )
        { 
        }

        public RequestDTO Execute()
        {
            
            RequestDTO request =  new RequestDTO_Builder()
               .WithCommand(2)
                .WithMemberId(ConsoleReader.ReadInt("\nMember ID"))
                .WithBookId(ConsoleReader.ReadInt("Book ID"))
                .Build();
            return request;
        }
    }
}
