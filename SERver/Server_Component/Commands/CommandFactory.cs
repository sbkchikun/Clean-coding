using DTOs;
namespace CommandLineUI.Commands

{
    class CommandFactory
    {

        public CommandFactory()
        {
        }

        public Command CreateCommand(RequestDTO request)
        {   
            switch (request.Command)
            {
                case RequestUseCase.BORROW_BOOK:
                    return new BorrowBookCommand(request.MemberId, request.BookId);

                case RequestUseCase.INITIALISE_DATABASE:
                    return new InitialiseDatabaseCommand();

                case RequestUseCase.RENEW_LOAN:
                    return new RenewLoanCommand(request.MemberId, request.BookId);

                case RequestUseCase.RETURN_BOOK:
                    return new ReturnBookCommand(request.MemberId, request.BookId);

                case RequestUseCase.VIEW_ALL_BOOKS:
                    return new ViewAllBooksCommand();

                case RequestUseCase.VIEW_ALL_MEMBERS:
                    return new ViewAllMembersCommand();

                case RequestUseCase.VIEW_CURRENT_LOANS:
                    return new ViewCurrentLoansCommand();

                default:
                    return new NullCommand();
            }
        }
    }
}
