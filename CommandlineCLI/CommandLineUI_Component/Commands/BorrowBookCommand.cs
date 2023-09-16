
using DTOs;
namespace CommandLineUI.Commands
{
    class BorrowBookCommand : Command
    {
        
        public BorrowBookCommand( )
        { 
        }

        public RequestDTO Execute( )
        {
            
            RequestDTO request =  new RequestDTO_Builder()
                .WithCommand(1)
                .WithMemberId(ConsoleReader.ReadInt("\nMember ID"))
                .WithBookId(ConsoleReader.ReadInt("Book ID"))
                .Build();
            return request;
        }
    }
}
