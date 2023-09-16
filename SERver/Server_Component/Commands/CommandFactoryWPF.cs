using DTOs;
namespace CommandLineUI.Commands

{
    class CommandFactoryWPF
    {

        public CommandFactoryWPF()
        {
        }

        public CommandWPF CreateCommand(RequestDTO request)
        {   
            switch (request.Command)
            {
                
                case RequestUseCase.VIEW_ALL_BOOKS:
                    return new ViewAllBooksCommandWPF();

                case RequestUseCase.VIEW_ALL_MEMBERS:
                    return new ViewAllMembersCommandWPF();

                case RequestUseCase.VIEW_CURRENT_LOANS:
                    return new ViewCurrentLoansCommandWPF();

                default:
                    return new NullCommandWPF();
            }
        }
    }
}
