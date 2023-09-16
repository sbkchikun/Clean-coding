using System.Windows.Controls;

namespace Windows.Commands
{
    class CommandFactory
    {

        public CommandFactory()
        {
        }

        public Command CreateCommand(int menuChoice,int memberId,int bookId)
        {
            switch (menuChoice)
            {
                case RequestUseCase.BORROW_BOOK:
                    return new BorrowBookCommand(memberId,bookId);
 
                case RequestUseCase.RENEW_LOAN:
                    return new RenewLoanCommand(memberId, bookId )   ;

                case RequestUseCase.RETURN_BOOK:
                    return new ReturnBookCommand(memberId, bookId );

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
