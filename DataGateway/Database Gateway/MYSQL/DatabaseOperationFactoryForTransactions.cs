using DTOs;
using System.Collections.Generic;

namespace DatabaseGateway
{
    class DatabaseOperationFactoryForTransactions
    {
        public const int SELECT_ALL = 1;
        public const int SELECT_BY_NAME = 2;
        public const int UPDATE_ITEM_ADD_QTY = 3;
        public const int UPDATE_ITEM_REMOVE_QTY = 4;
        public DatabaseInserter<TransactionDTO> CreateInserter()
        {
            return new InsertTransaction();
        }

        public ISelector<List<TransactionDTO>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL)
            {
                return new GetAllTransactions();
            }
            return new NullSelector<List<TransactionDTO>>();
        }

        public ISelector<List<TransactionDTO>> CreateSelector(int typeOfSelection, string employeeName)
        {
            switch (typeOfSelection)
            {
                case SELECT_BY_NAME:
                    return new FindTransactionsByEmployee(employeeName);
                default:
                    return new NullSelector<List<TransactionDTO>>();
            }
        }
    }
}
